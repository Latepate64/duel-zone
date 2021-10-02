using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.Triggered;
using DuelMastersModels.Choices;

namespace DuelMastersModels.Cards.Creatures
{
    public class PyrofighterMagnusAbility : AtTheEndOfYourTurn
    {
        public PyrofighterMagnusAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public PyrofighterMagnusAbility() : base()
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
