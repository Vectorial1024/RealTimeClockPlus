﻿using HugsLib;
using HugsLib.Settings;
using RealTimeClockPlus.PlayTimeTracker;
using RealTimeClockPlus.RealTimeReadout;
using System;
using UnityEngine;
using Verse;

namespace RealTimeClockPlus
{
    public class RealTimeClockPlusMain : ModBase
    {
        // Configs and stuff

        public static string MODSHORTID => "V1024-RTCP";

        public override string LogIdentifier => MODSHORTID;

        // Static objects

        private static RimWorldSPTT spttObject;

        public static RimWorldSPTT SessionPlayTimeTracker 
        {
            get
            {
                if (spttObject == null)
                {
                    spttObject = new RimWorldSPTT();
                }
                return spttObject;
            }
            private set
            {
                spttObject = value;
            }
        }

        // Settings

        public static SettingHandle<ClockReadoutFormatEnum> SettingHandle_ClockDisplayFormat { get; private set; }

        public static SettingHandle<TimerDisplayLocationEnum> SettingHandle_TimerDisplayLocation { get; private set; }

        public static SettingHandle<bool> SettingHandle_TimerUseColorGradient { get; private set; }

        public static SettingHandle<bool> SettingHandle_TimerUsesMillisecondPart { get; private set; }

        // Quick-access flags

        public static bool TimerIsDisplayedAtClock => SettingHandle_TimerDisplayLocation.Value == TimerDisplayLocationEnum.REALTIMECLOCK;

        public static bool TimerIsDisplayedAsAlert => SettingHandle_TimerDisplayLocation.Value == TimerDisplayLocationEnum.NOTIFICATION;

        public static bool TimerAlertShouldUseColorGradient => SettingHandle_TimerUseColorGradient.Value;

        public static bool TimerShouldIncludeMilliseconds => SettingHandle_TimerUsesMillisecondPart.Value;

        public static bool PlayTimeTrackerIsLoaded { get; internal set; } = false;

        // Constructor not needed

        // Base or extension methods

        public override void DefsLoaded()
        {
            PrepareModSettingHandles();
        }

        // User-defined methods

        public static void BeginOrResetTimer()
        {
            SessionPlayTimeTracker = new RimWorldSPTT();
        }
        
        /// <summary>
        /// Initializes and loads mod setting handles as prepared by HugsLib
        /// </summary>
        private void PrepareModSettingHandles()
        {
            SettingHandle_ClockDisplayFormat = Settings.GetHandle("enumClockDisplayFormat", "RTCP_DisplayFormatChoice_title".Translate(), "RTCP_DisplayFormatChoice_descr".Translate(), ClockReadoutFormatEnum.SIMPLE_24HR, null, "ClockReadoutFormat_");
            SettingHandle_TimerDisplayLocation = Settings.GetHandle("enumTimerDisplayLocation", "SPTT_DisplayLocation_title".Translate(), "SPTT_DisplayLocation_desc".Translate(), TimerDisplayLocationEnum.NOTIFICATION, null, "TimerDisplayLocation_");
            SettingHandle_TimerUseColorGradient = Settings.GetHandle("flagTimerUseColorGradient", "SPTT_UseColorGradient_title".Translate(), "SPTT_UseColorGradient_desc".Translate(), true);
            SettingHandle_TimerUsesMillisecondPart = Settings.GetHandle("flagTimerUseMilliseconds", "SPTT_UseMillisecondPart_title".Translate(), "SPTT_UseMillisecondPart_desc".Translate(), true);
        }

        public static void AccumulateTime(float amount)
        {
            SessionPlayTimeTracker?.AccumulateTime(amount);
        }
    }
}
