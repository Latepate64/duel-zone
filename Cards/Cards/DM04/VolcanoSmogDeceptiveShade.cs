using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM04
{
    class VolcanoSmogDeceptiveShade : Creature
    {
        public VolcanoSmogDeceptiveShade() : base("Volcano Smog, Deceptive Shade", 6, 5000, Engine.Subtype.Ghost, Civilization.Darkness)
        {
            AddStaticAbilities(new EachCivilizationCardCostsMoreEffect(Civilization.Light, 2));
        }
    }
}
