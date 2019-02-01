#!/bin/bash

cape="BB-BONE-BACONE"
clk=/sys/class/gpio/gpio2
serial=/sys/class/gpio/gpio4
latch=/sys/class/gpio/gpio5
clr=/sys/class/gpio/gpio48
button=/sys/class/gpio/gpio22
red=/sys/class/pwm/pwm0
green=/sys/class/pwm/pwm1
blue=/sys/class/pwm/pwm2
pot=/sys/devices/ocp*/bacon_adc_helper*/AIN5
pot_min=0
pot_max=1800000

function setup {
	local i

	# load cape if not loaded yet
	grep 2>&1 >/dev/null "$cape" ~/Documents/cmpe344/beaglebone-files/
	if [ $? -ne 0 ] ; then
		echo "$cape" >~/Documents/cmpe344/beaglebone-files/
		sleep 5
		# check if loaded
		grep 2>&1 >/dev/null "$cape" ~/Documents/cmpe344/beaglebone-files/
		if [ $? -ne 0 ] ; then
			echo "Failed to load $cape"
			exit 5
		fi
	fi
	# export the 3 pwms (it will fail if already exported but we don't care)
	for i in `seq 0 2` ; do
		echo $i 2>/dev/null >/sys/class/pwm/export
	done

	# bring 595 shift register out of clear
	echo 1 > ${clr}/value
}

function set_clk {
	echo $1 > "$clk/value"
}

function set_serial {
	echo $1 > "$serial/value"
}

function set_latch {
	echo $1 > "$latch/value"
}

function get_button {
	local v

	v=`cat "$button/value"`
	return $v
}

function get_button_press {
	# wait for down
	while true ; do
		get_button
		if [ $? -eq 0 ] ; then
			break
		fi
		sleep 0.2
	done
	# wait for up
	while true ; do
		get_button
		if [ $? -eq 1 ] ; then
			break
		fi
		sleep 0.2
	done
}

function get_pot {
	local v

	# read twice
	v=`cat $pot`
	v=`cat $pot`
	export POT_VALUE="$v"
	return 0
}

function set_pwm {

	local pwm
	local prev

	pwm="$1"

	# stop pwm
	
	prev=`cat $pwm/run`
	if [ x$prev == x1 ] ; then
		echo 0 > "$pwm/run"
	fi
	if [ x$3 != "x" ] ; then
		echo "$3" > "$pwm/duty_ns"
	fi
	if [ x$4 != "x" ] ; then
		echo "$4" > "$pwm/period_ns"
	fi
	echo $2 > "$pwm/run"
}

function set_8seg {
	local t
	local i
	local v

	set_latch 0

	v=($*)
	for i in `seq 0 7` ; do
		# t = !v[7-i]
		t=$((!${v[$((7 - $i))]}))
		set_clk 0
		set_serial $t
		set_clk 1
	done

	set_latch 1
}

function set_digit {

	local dot
	local d

	if [ x$1 == x ] ; then
		echo "set_digit: missing arguments"
		exit 5
	fi

	dot=`echo $1 | sed 's/^[0-9]//'`
	if [ x$dot == "x." ] ; then
		d=1
	else
		d=0
	fi

	case $1 in
		0*)  set_8seg 1 1 1 1 1 1 0 $d ;;
		1*)  set_8seg 0 1 1 0 0 0 0 $d ;;
		2*)  set_8seg 1 1 0 1 1 0 1 $d ;;
		3*)  set_8seg 1 1 1 1 0 0 1 $d ;;
		4*)  set_8seg 0 1 1 0 0 1 1 $d ;;
		5*)  set_8seg 1 0 1 1 0 1 1 $d ;;
		6*)  set_8seg 1 0 1 1 1 1 1 $d ;;
		7*)  set_8seg 1 1 1 0 0 0 0 $d ;;
		8*)  set_8seg 1 1 1 1 1 1 1 $d ;;
		9*)  set_8seg 1 1 1 1 0 1 1 $d ;;
		off) set_8seg 0 0 0 0 0 0 0 0  ;;
		on)  set_8seg 1 1 1 1 1 1 1 1  ;;
	esac
}

# setup everything
setup

# 7 segment display test

set_pwm $red 0
sleep 0.5
set_pwm $green 0
sleep 0.5
set_pwm $blue 0
sleep 0.5

echo "Red PWM"
set_pwm $red 1 10000 20000
sleep 1
set_pwm $red 0
sleep 1

echo "Green PWM"
set_pwm $green 1 10000 20000
sleep 1
set_pwm $green 0
sleep 1

echo "Blue PWM"
set_pwm $blue 1 10000 20000
sleep 1
set_pwm $blue 0
sleep 1

echo "7 segment display all off"
set_digit off
sleep 1

echo "7 segment display all on"
set_digit on
sleep 1

echo "7 segment display digit check"
for i in `seq 0 9` ; do
	set_digit $i
	sleep 0.5
done

echo "7 segment display digit check (with a dot)"
for i in `seq 0 9` ; do
	set_digit "$i."
      sleep 0.5
done

echo "Press button to continue"
get_button_press
echo "button pressed"

echo "Slider test (press button to exit)"

while true ; do
	get_button
	if [ $? -eq 0 ] ; then
		break
	fi
	get_pot
	v=$POT_VALUE
	d=$(( ($v * 10) / $pot_max))
	set_digit $d

	r=$(( ($v * 20000) / $pot_max))

	set_pwm $red 1 $r 20000
	set_pwm $green 1 $r 20000
	set_pwm $blue 1 $r 20000
done

set_pwm $red 0
set_pwm $green 0
set_pwm $blue 0

set_digit off