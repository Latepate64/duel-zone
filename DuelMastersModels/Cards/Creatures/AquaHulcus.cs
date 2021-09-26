using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Choices;
using System;

namespace DuelMastersModels.Cards.Creatures
{
    public class AquaHulcus : Creature
    {
        public AquaHulcus(Guid owner) : base(owner, 3, Civilization.Water, 2000, Race.LiquidPeople)
        {
            TriggeredAbilities.Add(new AquaHulcusAbility(Id, owner));
        }

        public AquaHulcus(AquaHulcus x) : base(x) { }

        public override Card Copy()
        {
            return new AquaHulcus(this);
        }
    }

    public class AquaHulcusAbility : WhenYouPutThisCreatureIntoTheBattleZone
    {
        public AquaHulcusAbility(Guid source, Guid controller) : base(source, controller) { }

        public AquaHulcusAbility(AquaHulcusAbility ability) : base(ability)
        {
        }

        public override NonStaticAbility Copy()
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
