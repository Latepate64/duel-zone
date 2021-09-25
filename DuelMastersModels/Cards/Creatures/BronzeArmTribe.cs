using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Choices;
using System;

namespace DuelMastersModels.Cards.Creatures
{
    public class BronzeArmTribe : Creature
    {
        public BronzeArmTribe(Creature creature) : base(creature)
        {
            TriggerAbilities.Add(new BronzeArmTribeAbility(Id));
        }

        public BronzeArmTribe() : base(3, Civilization.Nature, 1000, Race.BeastFolk)
        {
        }

        public override Card Copy()
        {
            return new BronzeArmTribe(this);
        }
    }

    internal class BronzeArmTribeAbility : TriggeredAbility
    {
        public BronzeArmTribeAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public BronzeArmTribeAbility(Guid source) : base(new WhenYouPutThisCreatureIntoTheBattleZone(), source)
        {
        }

        public override Ability Copy()
        {
            return new BronzeArmTribeAbility(this);
        }

        public override Choice Resolve(Duel duel, Decision choice)
        {
            duel.GetPlayer(Controller).PutFromTopOfDeckIntoManaZone(duel);
            return null;
        }
    }
}
