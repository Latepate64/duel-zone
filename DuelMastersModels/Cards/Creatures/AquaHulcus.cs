using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Choices;

namespace DuelMastersModels.Cards.Creatures
{
    public class AquaHulcus : Creature
    {
        public AquaHulcus() : base(3, Civilization.Water, 2000, Race.LiquidPeople)
        {
            TriggerAbilities.Add(new AquaHulcusAbility(this));
        }

        public override Card Copy()
        {
            return Copy(new AquaHulcus());
        }
    }

    public class AquaHulcusAbility : TriggeredAbility
    {
        public AquaHulcusAbility(Card source) : base(new WhenYouPutThisCreatureIntoTheBattleZone(), source) { }

        public override Choice Resolve(Duel duel, Choice choice)
        {
            if (choice == null) { return new YesNoChoice(Controller); }
            if ((choice as YesNoChoice).Decision) { duel.GetPlayer(Controller).DrawCards(1); }
            return null;
        }

        public override Ability Copy()
        {
            return Copy(new AquaHulcusAbility(Source));
        }
    }
}
