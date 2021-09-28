using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Choices;
using System;

namespace DuelMastersModels.Cards.Creatures
{
    public class BronzeArmTribeAbility : WhenYouPutThisCreatureIntoTheBattleZone
    {
        public BronzeArmTribeAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public BronzeArmTribeAbility(Guid source, Guid controller) : base(source, controller)
        {
        }

        public override Ability Copy()
        {
            return new BronzeArmTribeAbility(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            duel.GetPlayer(Controller).PutFromTopOfDeckIntoManaZone(duel);
            return null;
        }
    }
}
