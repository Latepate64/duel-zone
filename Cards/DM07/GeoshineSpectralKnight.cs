using TriggeredAbilities;

namespace Cards.DM07
{
    sealed class GeoshineSpectralKnight : Engine.Creature
    {
        public GeoshineSpectralKnight() : base("Geoshine, Spectral Knight", 5, 4000, Interfaces.Race.RainbowPhantom, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect()));
        }
    }
}
