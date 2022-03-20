using Common;

namespace Cards.Cards.DM03
{
    class RagingDashHorn : Creature
    {
        public RagingDashHorn() : base("Raging Dash-Horn", 5, 4000, Subtype.HornedBeast, Civilization.Nature)
        {
            var condition = new Conditions.AllOfCivilizationCondition(Civilization.Nature);
            AddAbilities(new StaticAbilities.WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerAbility(Civilization.Nature, 3000), new StaticAbilities.DoubleBreakerAbility(condition));
        }
    }
}
