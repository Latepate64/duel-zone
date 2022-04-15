using Cards.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class Mudman : Creature
    {
        public Mudman() : base("Mudman", 4, 2000, Engine.Subtype.Hedrian, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(Engine.Civilization.Darkness, 2000));
        }
    }
}
