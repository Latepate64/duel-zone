using Cards.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class BabyZoppe : Creature
    {
        public BabyZoppe() : base("Baby Zoppe", 3, 2000, Engine.Race.FireBird, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(2000, Engine.Civilization.Fire));
        }
    }
}
