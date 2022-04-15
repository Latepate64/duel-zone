namespace Cards.Cards.DM07
{
    class GeoshineSpectralKnight : Creature
    {
        public GeoshineSpectralKnight() : base("Geoshine, Spectral Knight", 5, 4000, Engine.Subtype.RainbowPhantom, Engine.Civilization.Light)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayChooseDarknessOrFireCreatureInTheBattleZoneAndTapItEffect());
        }
    }
}
