using HarmonyLib;
using RimWorld;
using System;
using UnityEngine;
using Verse;

namespace RealTimeClockPlus.RealTimeReadout
{
    [HarmonyPatch(typeof(GlobalControlsUtility))]
    [HarmonyPatch("DoRealtimeClock", MethodType.Normal)]
    public class PreFix_DoRealTimeClock
    {
        [HarmonyPriority(Priority.Normal)]
        [HarmonyPrefix]
        public static bool PreFix(float leftX, float width, ref float curBaseY)
        {
            Rect rect = new Rect(leftX - 20f, curBaseY - 26f, width + 20f - 7f, 26f);
            Text.Anchor = TextAnchor.MiddleRight;
            Widgets.Label(rect, GetClockAreaReadout());
            Text.Anchor = TextAnchor.UpperLeft;
            curBaseY -= 26f;
            return false;
        }

        private static string GetClockAreaReadout()
        {
            string result = ClockReadoutStringBuilder.GenerateTimeStringNow();
            if (RealTimeClockPlusMain.TimerIsDisplayedAtClock)
            {
                result += " (SPT ";
                result += RealTimeClockPlusMain.SessionPlayTimeTracker.ToString();
                result += ")";
            }
            // Log.Error("Result is: " + result);
            return result;
        }
    }
}
