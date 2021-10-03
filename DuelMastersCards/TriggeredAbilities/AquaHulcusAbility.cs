using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;

namespace DuelMastersCards.TriggeredAbilities
{
    public class AquaHulcusAbility : WhenYouPutThisCreatureIntoTheBattleZoneAbility
    {
        public AquaHulcusAbility() : base() { }

        public AquaHulcusAbility(AquaHulcusAbility ability) : base(ability)
        {
        }

        public override Ability Copy()
        {
            return new AquaHulcusAbility(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            if (decision == null)
            {
                return new YesNoChoice(Controller);
            }
            if ((decision as YesNoDecision).Decision)
            {
                duel.GetPlayer(Controller).DrawCards(1, duel);
            }
            return null;
        }
    }
}
