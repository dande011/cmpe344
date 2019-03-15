﻿/*
 * Project: AVRDUDESS - A GUI for AVRDUDE
 * Author: Zak Kemble, me@zakkemble.co.uk
 * Copyright: (C) 2013 by Zak Kemble
 * License: GNU GPL v3 (see License.txt)
 * Web: http://blog.zakkemble.co.uk/avrdudess-a-gui-for-avrdude/
 */

using System;

namespace avrdudess
{
    public class MCU : Part
    {
        public MCU(string name, string fullName)
            : base(name, fullName)
        {

        }
    }
}
