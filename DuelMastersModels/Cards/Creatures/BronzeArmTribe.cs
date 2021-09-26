using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Choices;
using System;

namespace DuelMastersModels.Cards.Creatures
{
    public class BronzeArmTribe : Creature
    {
        public BronzeArmTribe(Guid owner) : base(owner, 3, Civilization.Nature, 1000, Race.BeastFolk)
        {
            TriggeredAbilities.Add(new BronzeArmTribeAbility(Id, owner));
        }

        public BronzeArmTribe(Creature creature) : base(creature)
        {
        }

        public override Card Copy()
        {
            return new BronzeArmTribe(this);
        }
    }

    internal class BronzeArmTribeAbility : WhenYouPutThisCreatureIntoTheBattleZone
    {
        public BronzeArmTribeAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public BronzeArmTribeAbility(Guid source, Guid controller) : base(source, controller)
        {
        }

        public override NonStaticAbility Copy()
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
