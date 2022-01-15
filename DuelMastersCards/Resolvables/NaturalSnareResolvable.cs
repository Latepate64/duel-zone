using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    class NaturalSnareResolvable : Resolvable
    {
        public NaturalSnareResolvable()
        {
        }

        public NaturalSnareResolvable(Resolvable resolvable) : base(resolvable)
        {
        }

        public override Resolvable Copy()
        {
            return new NaturalSnareResolvable(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            var opponent = duel.GetOpponent(duel.GetPlayer(Controller));
            if (decision == null)
            {
                var choosable = opponent.BattleZone.GetChoosableCreatures(duel);
                if (choosable.Count() > 1)
                {
                    return new GuidSelection(Controller, choosable, 1, 1);
                }
                else if (choosable.Any())
                {
                    duel.Move(choosable.Single(), DuelMastersModels.Zones.ZoneType.BattleZone, DuelMastersModels.Zones.ZoneType.ManaZone);
                    return null;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                duel.Move(duel.GetPermanent((decision as GuidDecision).Decision.Single()), DuelMastersModels.Zones.ZoneType.BattleZone, DuelMastersModels.Zones.ZoneType.ManaZone);
                return null;
            }
        }
    }
}
