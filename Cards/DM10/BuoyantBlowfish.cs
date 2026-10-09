using ContinuousEffects.PowerModifying;

namespace Cards.DM10
{
    sealed class BuoyantBlowfish : Creature
    {
        public BuoyantBlowfish() : base("Buoyant Blowfish", 5, 1000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new GetsPowerForEachTappedCardInYourOpponentsManaZoneEffect(1000));
        }
    }
}
