using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealTimeClockPlus
{
    public class ClockStringCustomDrawer
    {
        public static string GetFormattingStringFromDisplayEnum()
        {
            EnumDisplayFormat formatEnum = RealTimeClockPlusMain.SettingHandle_DisplayOption;

            switch (formatEnum)
            {
                case EnumDisplayFormat.SIMPLE_24HR:
                    return "HH:mm";
                case EnumDisplayFormat.SIMPLE_12HR:
                    return "hh:mm tt";
                case EnumDisplayFormat.FULL_24HR:
                    return "HH:mm:ss";
                case EnumDisplayFormat.FULL_12HR:
                    return "hh:mm:ss tt";
                default:
                    return "HH:mm";
            }
        }
    }
}
