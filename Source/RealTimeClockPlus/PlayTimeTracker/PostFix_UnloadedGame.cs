using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Verse;

namespace RealTimeClockPlus.PlayTimeTracker
{
    [HarmonyPatch(typeof(GenScene))]
    [HarmonyPatch("GoToMainMenu", MethodType.Normal)]
    public class PostFix_UnloadedGame
    {
        [HarmonyPostfix]
        public static void PostFix()
        {
            // peek the stack trace...
            StackTrace trace = new StackTrace();
            Log.Error(trace.ToStringSafe());
            RealTimeClockPlusMain.IdempotentResetTimer();
        }
    }
}
