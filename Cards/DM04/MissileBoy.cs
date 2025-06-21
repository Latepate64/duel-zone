using ContinuousEffects;
using Engine.ContinuousEffects;

namespace Cards.DM04
{
    class MissileBoy : Engine.Creature
    {
        public MissileBoy() : base("Missile Boy", 3, 1000, Interfaces.Race.Human, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new MissileBoyEffect());
        }
    }

    class MissileBoyEffect : EachCivilizationCardCostsMoreEffect
    {
        public MissileBoyEffect(EachCivilizationCardCostsMoreEffect effect) : base(effect)
        {
        }

        public MissileBoyEffect(Interfaces.Civilization civilization = Interfaces.Civilization.Light) : base(1, civilization)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new MissileBoyEffect(this);
        }
    }
}
