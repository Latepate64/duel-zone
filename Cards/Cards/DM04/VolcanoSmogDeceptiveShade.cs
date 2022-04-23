using Cards.ContinuousEffects;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class VolcanoSmogDeceptiveShade : Creature
    {
        public VolcanoSmogDeceptiveShade() : base("Volcano Smog, Deceptive Shade", 6, 5000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new VolcanoSmogEffect());
        }
    }

    class VolcanoSmogEffect : EachCivilizationCardCostsMoreEffect
    {
        public VolcanoSmogEffect(EachCivilizationCardCostsMoreEffect effect) : base(effect)
        {
        }

        public VolcanoSmogEffect(Engine.Civilization civilization = Engine.Civilization.Light) : base(2, civilization)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new VolcanoSmogEffect(this);
        }
    }
}
