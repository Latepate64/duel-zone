using Cards.TriggeredAbilities;

namespace Cards.Cards.DM07
{
    class GeoshineSpectralKnight : Engine.Creature
    {
        public GeoshineSpectralKnight() : base("Geoshine, Spectral Knight", 5, 4000, Engine.Race.RainbowPhantom, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect()));
        }
    }
}
