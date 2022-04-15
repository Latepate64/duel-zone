using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM03
{
    class Mudman : Creature
    {
        public Mudman() : base("Mudman", 4, 2000, Engine.Subtype.Hedrian, Civilization.Darkness)
        {
            AddStaticAbilities(new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(Civilization.Darkness, 2000));
        }
    }
}
