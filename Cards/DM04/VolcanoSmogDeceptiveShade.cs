using ContinuousEffects;
using Engine.ContinuousEffects;

namespace Cards.DM04
{
    class VolcanoSmogDeceptiveShade : Engine.Creature
    {
        public VolcanoSmogDeceptiveShade() : base("Volcano Smog, Deceptive Shade", 6, 5000, Interfaces.Race.Ghost, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new VolcanoSmogEffect());
        }
    }

    class VolcanoSmogEffect : EachCivilizationCardCostsMoreEffect
    {
        public VolcanoSmogEffect(EachCivilizationCardCostsMoreEffect effect) : base(effect)
        {
        }

        public VolcanoSmogEffect(Interfaces.Civilization civilization = Interfaces.Civilization.Light) : base(2, civilization)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new VolcanoSmogEffect(this);
        }
    }
}
