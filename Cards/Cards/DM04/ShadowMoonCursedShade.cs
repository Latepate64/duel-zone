using Cards.ContinuousEffects;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class ShadowMoonCursedShade : Creature
    {
        public ShadowMoonCursedShade() : base("Shadow Moon, Cursed Shade", 4, 3000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ShadowMoonEffect());
        }
    }

    class ShadowMoonEffect : EachOtherCivilizationCreaturePowerEffect
    {
        public ShadowMoonEffect(EachOtherCivilizationCreaturePowerEffect effect) : base(effect)
        {
        }

        public ShadowMoonEffect() : base(Engine.Civilization.Darkness, 2000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ShadowMoonEffect(this);
        }
    }
}
