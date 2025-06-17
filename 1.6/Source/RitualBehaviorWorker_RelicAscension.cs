using System.Collections.Generic;
using System.Linq;
using Verse;
using Verse.AI.Group;

namespace RimWorld
{
    public class RitualBehaviorWorker_RelicAscension : RitualBehaviorWorker
    {
        public RitualBehaviorWorker_RelicAscension()
        {

        }

        public RitualBehaviorWorker_RelicAscension(RitualBehaviorDef def) : base(def)
        {

        }

        protected override LordJob CreateLordJob(TargetInfo target, Pawn organizer, Precept_Ritual ritual, RitualObligation obligation, RitualRoleAssignments assignments)
        {
            Pawn initiator = assignments.AssignedPawns("initiator").First<Pawn>();
            return new LordJob_Joinable_Speech(target, initiator, ritual, this.def.stages, assignments, false);
        }

        protected override void PostExecute(TargetInfo target, Pawn organizer, Precept_Ritual ritual, RitualObligation obligation, RitualRoleAssignments assignments)
        {
            
        }

        public override string CanStartRitualNow(TargetInfo target, Precept_Ritual ritual, Pawn selectedPawn = null, Dictionary<string, Pawn> forcedForRole = null)
        {
            Precept_Role precept_Role = ritual.ideo.RolesListForReading.FirstOrDefault((Precept_Role r) => r.def == PreceptDefOf.IdeoRole_Leader);
            if (precept_Role == null)
            {
                return null;
            }
            if (precept_Role.ChosenPawnSingle() == null)
            {
                return "CantStartRitualRoleNotAssigned".Translate(precept_Role.LabelCap);
            }
            int numRelicsPresent = 0;
            Room room = target.Cell.GetRoom(target.Map);
            if (room != null && !room.TouchesMapEdge)
            {
                foreach (Thing thing in room.ContainedThings(ThingDefOf.Reliquary))
                {
                    CompRelicContainer compRelicContainer = thing.TryGetComp<CompRelicContainer>();
                    if (compRelicContainer != null)
                    {
                        Thing containedThing = compRelicContainer.ContainedThing;
                        Precept_ThingStyle precept_ThingStyle;
                        if (containedThing == null)
                        {
                            precept_ThingStyle = null;
                        }
                        else
                        {
                            CompStyleable compStyleable = containedThing.TryGetComp<CompStyleable>();
                            precept_ThingStyle = ((compStyleable != null) ? compStyleable.SourcePrecept : null);
                        }
                        Precept_ThingStyle precept_ThingStyle2 = precept_ThingStyle;
                        if (precept_ThingStyle2 != null && precept_ThingStyle2.ideo == ritual.ideo)
                        {
                            numRelicsPresent++;
                        }
                    }
                }
            }
            int numRelicsTotal = ritual.ideo.PreceptsListForReading.Where(p => p is Precept_Relic).Count();
            if (numRelicsPresent < numRelicsTotal)
            {
                return "RelicRituaryAscension_CantStartRitualRelicsNotPresent".Translate();
            }
            return base.CanStartRitualNow(target, ritual, selectedPawn, forcedForRole);
        }
    }
}
