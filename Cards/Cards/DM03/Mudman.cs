using Common;

namespace Cards.Cards.DM03
{
    class Mudman : Creature
    {
        public Mudman() : base("Mudman", 4, 2000, Subtype.Hedrian, Civilization.Darkness)
        {
            AddAbilities(new StaticAbilities.WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerAbility(Civilization.Darkness, 2000));
        }
    }
}
