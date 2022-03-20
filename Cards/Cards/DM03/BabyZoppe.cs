using Common;

namespace Cards.Cards.DM03
{
    class BabyZoppe : Creature
    {
        public BabyZoppe() : base("Baby Zoppe", 3, 2000, Subtype.FireBird, Civilization.Fire)
        {
            AddAbilities(new StaticAbilities.WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerAbility(Civilization.Fire, 2000));
        }
    }
}
