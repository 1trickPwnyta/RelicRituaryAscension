using RelicRituaryAscension;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace RimWorld
{
    public class RitualOutcomeEffectWorker_RelicAscension : RitualOutcomeEffectWorker
    {
        public override bool SupportsAttachableOutcomeEffect
        {
            get
            {
                return false;
            }
        }

        public RitualOutcomeEffectWorker_RelicAscension()
        {

        }

        public RitualOutcomeEffectWorker_RelicAscension(RitualOutcomeEffectDef def) : base(def)
        {

        }

        public override void Apply(float progress, Dictionary<Pawn, int> totalPresence, LordJob_Ritual jobRitual)
        {
            SoundDefOf.Archotech_Invoked.PlayOneShotOnCamera();
            ScreenFader.StartFade(Color.white, 5f);
            EndGameTimer.timeLeft = 5f;
            GameObject.Find("GameRoot").AddComponent<EndGameTimer>();
            RelicAscensionCountdown.pawns = totalPresence.Keys.ToList();
        }

        public override OutcomeChance GetForcedOutcome(Precept_Ritual ritual, TargetInfo ritualTarget, RitualObligation obligation, RitualRoleAssignments assignments)
        {
            return this.def.outcomeChances[0];
        }

        public override IEnumerable<string> BlockingIssues(Precept_Ritual ritual, TargetInfo target, RitualRoleAssignments assignments)
        {
            yield break;
        }
    }
}
