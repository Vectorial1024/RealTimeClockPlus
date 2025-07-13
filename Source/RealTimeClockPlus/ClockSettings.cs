using RealTimeClockPlus.PlayTimeTracker;
using RealTimeClockPlus.RealTimeReadout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace RealTimeClockPlus
{
    public class ClockSettings : ModSettings
    {
        // to make the listing more clickable
        public const int StandardRowHeight = 30;

        public ClockReadoutFormatEnum clockDisplayFormat;
        private TimerDisplayLocationEnum spttDisplayLocation;
        public bool spttUseGradient = false;
        public bool spttTrackMilliseconds = false;
        public bool spttMinimal = false;

        public bool DisplaySpttAtClock => spttDisplayLocation == TimerDisplayLocationEnum.REALTIMECLOCK;
        public bool DisplaySpttAsAlert => spttDisplayLocation == TimerDisplayLocationEnum.NOTIFICATION;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref clockDisplayFormat, "clockDisplayFormat", ClockReadoutFormatEnum.SIMPLE_24HR);
            Scribe_Values.Look(ref spttDisplayLocation, "spttDisplayLocation", TimerDisplayLocationEnum.NOTIFICATION);
            Scribe_Values.Look(ref spttUseGradient, "spttUseGradient", true);
            Scribe_Values.Look(ref spttTrackMilliseconds, "spttTrackMilliseconds", true);
            Scribe_Values.Look(ref spttMinimal, "spttMinimal", false);
            base.ExposeData();
        }

        public void DoSettingsWindowContents(Rect inRect)
        {
            // since we no longer rely on HugsLib, we gotta do the UI ourselves
            Listing_Standard listing = new Listing_Standard();

            // ...
            listing.Begin(inRect);

            // todo use radio buttons instead of the dropdown

            // todo display format

            // todo sptt display location

            // todo sptt gradient
            listing.CheckboxLabeled("SPTT_UseColorGradient_title".Translate(), ref spttUseGradient, "SPTT_UseColorGradient_desc".Translate(), StandardRowHeight);

            // todo sptt milliseconds
            listing.CheckboxLabeled("SPTT_UseMillisecondPart_title".Translate(), ref spttTrackMilliseconds, "SPTT_UseMillisecondPart_desc".Translate(), StandardRowHeight);

            // todo sptt minimal
            listing.CheckboxLabeled("SPTT_BeMinimalist_title".Translate(), ref spttMinimal, "SPTT_BeMinimalist_desc".Translate(), StandardRowHeight);

            // all done
            listing.End();
        }
    }
}
