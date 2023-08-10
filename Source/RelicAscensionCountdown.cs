using RimWorld;
using System.Collections.Generic;
using System.Text;
using Verse;

namespace RelicRituaryAscension
{
    public class RelicAscensionCountdown
    {
        public static List<Pawn> pawns;

        public static void EndGame()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Pawn pawn in pawns)
            {
                stringBuilder.AppendLine("   " + pawn.LabelCap);
                Find.StoryWatcher.statsRecord.colonistsLaunched++;
                pawn.Destroy();
            }
            GameVictoryUtility.ShowCredits(GameVictoryUtility.MakeEndCredits("RelicRituaryAscension_GameOverRelicRitualInvokedIntro".Translate(), "RelicRituaryAscension_GameOverRelicRitualInvokedEnding".Translate(), stringBuilder.ToString(), "RelicRituaryAscension_GameOverColonistsAscended", pawns), SongDefOf.ArchonexusVictorySong);
        }
    }
}
