using HarmonyLib;
using Verse;

namespace RealTimeClockPlus.PlayTimeTracker
{
    [HarmonyPatch(typeof(GenScene))]
    [HarmonyPatch(nameof(GenScene.GoToMainMenu), MethodType.Normal)]
    public class PostFix_UnloadedGame
    {
        [HarmonyPostfix]
        public static void PostFix()
        {
            // peek the stack trace...
            // StackTrace trace = new StackTrace();
            // Log.Error(trace.ToStringSafe());
            RealTimeClockPlusMod.IdempotentResetTimer();
        }
    }
}
