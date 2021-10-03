using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;

namespace DuelMastersCards.TriggeredAbilities
{
    public class PyrofighterMagnusAbility : AtTheEndOfYourTurnAbility
    {
        public PyrofighterMagnusAbility() : base()
        {
        }

        public PyrofighterMagnusAbility(PyrofighterMagnusAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new PyrofighterMagnusAbility(this);
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
