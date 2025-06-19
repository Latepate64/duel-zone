using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class CosmogoldSpectralKnight : Engine.Creature
    {
        public CosmogoldSpectralKnight() : base("Cosmogold, Spectral Knight", 4, 3000, Engine.Race.RainbowPhantom, Engine.Civilization.Light)
        {
            AddAbilities(new TapAbility(new OneShotEffects.ReturnSpellFromYourManaZoneToYourHandEffect()));
        }
    }
}
