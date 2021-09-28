using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Choices;
using System;

namespace DuelMastersModels.Cards.Creatures
{
    public class AquaHulcusAbility : WhenYouPutThisCreatureIntoTheBattleZone
    {
        public AquaHulcusAbility(Guid source, Guid controller) : base(source, controller) { }

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
