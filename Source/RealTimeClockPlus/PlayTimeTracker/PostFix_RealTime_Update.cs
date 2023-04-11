using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace RealTimeClockPlus.PlayTimeTracker
{
    [HarmonyPatch(typeof(RealTime))]
    [HarmonyPatch("Update", MethodType.Normal)]
    public class PostFix_RealTime_Update
    {
        private static bool ignoreNext = false;

        [HarmonyPostfix]
        public static void PostFix()
        {
            if (Current.Game == null)
            {
                // not in the play map (eg, in the main menu); irrelevant!
                return;
            }
            if (!Application.isFocused && !Prefs.RunInBackground)
            {
                // If run-in-background is inactive, and the player switches away,
                // This will only be executed once only.
                // The next execution will incorrectly obtain a very high deltaTime value.
                ignoreNext = true;
                return;
            }
            if (ignoreNext)
            {
                ignoreNext = false;
                return;
            }
            RealTimeClockPlusMain.AccumulateTime(RealTime.realDeltaTime);
        }
    }
}
