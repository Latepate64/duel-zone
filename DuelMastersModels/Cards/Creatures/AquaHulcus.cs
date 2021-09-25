using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Choices;

namespace DuelMastersModels.Cards.Creatures
{
    public class AquaHulcus : Creature
    {
        public AquaHulcus() : base(3, Civilization.Water, 2000, Race.LiquidPeople)
        {
            TriggerAbilities.Add(new AquaHulcusAbility(Id));
        }

        public AquaHulcus(AquaHulcus x) : base(x) { }

        public override Card Copy()
        {
            return new AquaHulcus(this);
        }
    }

    public class AquaHulcusAbility : TriggeredAbility
    {
        public AquaHulcusAbility(System.Guid source) : base(new WhenYouPutThisCreatureIntoTheBattleZone(), source) { }

        public AquaHulcusAbility(AquaHulcusAbility ability) : base(ability)
        {
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

        public override Ability Copy()
        {
            return new AquaHulcusAbility(this);
        }
    }
}
