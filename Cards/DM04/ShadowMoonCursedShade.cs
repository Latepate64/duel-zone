using ContinuousEffects;
using Engine.ContinuousEffects;

namespace Cards.DM04
{
    class ShadowMoonCursedShade : Engine.Creature
    {
        public ShadowMoonCursedShade() : base("Shadow Moon, Cursed Shade", 4, 3000, Interfaces.Race.Ghost, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ShadowMoonEffect());
        }
    }

    class ShadowMoonEffect : EachOtherCivilizationCreaturePowerEffect
    {
        public ShadowMoonEffect(EachOtherCivilizationCreaturePowerEffect effect) : base(effect)
        {
        }

        public ShadowMoonEffect() : base(Interfaces.Civilization.Darkness, 2000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ShadowMoonEffect(this);
        }
    }
}
