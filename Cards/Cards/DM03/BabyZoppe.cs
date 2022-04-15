using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM03
{
    class BabyZoppe : Creature
    {
        public BabyZoppe() : base("Baby Zoppe", 3, 2000, Engine.Subtype.FireBird, Civilization.Fire)
        {
            AddStaticAbilities(new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(Civilization.Fire, 2000));
        }
    }
}
