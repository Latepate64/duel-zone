using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;

namespace DuelMastersCards.Resolvables
{
    public class PyrofighterMagnusResolvable : Resolvable
    {
        public PyrofighterMagnusResolvable() : base()
        {
        }

        public PyrofighterMagnusResolvable(PyrofighterMagnusResolvable ability) : base(ability)
        {
        }

        public override Resolvable Copy()
        {
            return new PyrofighterMagnusResolvable(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            // Return this creature to your hand.
            var creature = duel.GetPermanent(Source);
            duel.GetPlayer(creature.Controller).ReturnFromBattleZoneToHand(creature, duel);
            return null;
        }
    }
}
