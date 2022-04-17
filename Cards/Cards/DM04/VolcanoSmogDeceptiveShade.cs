using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class VolcanoSmogDeceptiveShade : Creature
    {
        public VolcanoSmogDeceptiveShade() : base("Volcano Smog, Deceptive Shade", 6, 5000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new EachCivilizationCardCostsMoreEffect(Engine.Civilization.Light, 2));
        }
    }
}
