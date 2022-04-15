using Common;

namespace Cards.Cards.DM07
{
    class GeoshineSpectralKnight : Creature
    {
        public GeoshineSpectralKnight() : base("Geoshine, Spectral Knight", 5, 4000, Engine.Subtype.RainbowPhantom, Civilization.Light)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect());
        }
    }
}
