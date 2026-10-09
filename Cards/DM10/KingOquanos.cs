using ContinuousEffects.AbilityAdding;
using ContinuousEffects.PowerModifying;

namespace Cards.DM10
{
    sealed class KingOquanos : Creature
    {
        public KingOquanos() : base("King Oquanos", 8, 2000, Interfaces.Race.Leviathan, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new GetsPowerForEachTappedCardInYourOpponentsManaZoneEffect(1000), new PoweredDoubleBreaker());
        }
    }
}
