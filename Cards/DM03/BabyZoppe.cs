using ContinuousEffects;

namespace Cards.DM03
{
    sealed class BabyZoppe : Engine.Creature
    {
        public BabyZoppe() : base("Baby Zoppe", 3, 2000, Interfaces.Race.FireBird, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(2000, Interfaces.Civilization.Fire));
        }
    }
}
