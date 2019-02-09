using HugsLib;
using HugsLib.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace RealTimeClockPlus
{
    public class RealTimeClockPlusMain : ModBase
    {
        public static string MODID
        {
            get
            {
                return "com.vectorial1024.rimworld.rtcp";
            }
        }

        /// <summary>
        /// Already includes a space character.
        /// </summary>
        public static string MODPREFIX
        {
            get
            {
                return "[V1024-RTCP] ";
            }
        }

        public override string ModIdentifier
        {
            get
            {
                return MODID;
            }
        }

        public static SettingHandle<EnumDisplayFormat> SettingHandle_DisplayOption { get; private set; }

        public override void DefsLoaded()
        {
            PrepareModSettingHandles();
        }

        private void PrepareModSettingHandles()
        {
            SettingHandle_DisplayOption = Settings.GetHandle("enumDisplayFormat", "RTCP_DisplayFormatChoice_title".Translate(), "RTCP_DisplayFormatChoice_descr".Translate(), EnumDisplayFormat.SIMPLE_24HR, null, "StandardDisplayFormat_");
        }
    }
}
