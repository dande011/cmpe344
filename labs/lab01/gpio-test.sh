echo '7 7 7 7' > /proc/sys/kernel/printk
config-pin P9.42 pwm
config-pin -q P9.42
config-pin P9.16 pwm
config-pin -q P9.16
config-pin P9.42 pwm
config-pin -q P9.42

for i in `find /sys |grep pwmchip|grep /export$`
do 
   echo $1 > $i
   ls $i
done

for i in `find /sys |grep pwmchip|grep /pwm$1 |grep enable$`
do 
   echo 1 > $i
   echo $i: `cat $i`
done


for i in `find /sys |grep pwmchip|grep /pwm$1 |grep period$`
do 
   echo $2 > $i
   echo $i: `cat $i`
done

for i in `find /sys |grep pwmchip|grep /pwm$1 |grep duty_cycle$`
do 
   echo $3 > $i
   echo $i: `cat $i`
done