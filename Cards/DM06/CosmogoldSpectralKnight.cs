using Engine.Abilities;

namespace Cards.DM06
{
    class CosmogoldSpectralKnight : Engine.Creature
    {
        public CosmogoldSpectralKnight() : base("Cosmogold, Spectral Knight", 4, 3000, Interfaces.Race.RainbowPhantom, Interfaces.Civilization.Light)
        {
            AddAbilities(new TapAbility(new OneShotEffects.ReturnSpellFromYourManaZoneToYourHandEffect()));
        }
    }
}
