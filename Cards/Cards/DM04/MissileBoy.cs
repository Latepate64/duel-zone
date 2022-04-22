using Cards.ContinuousEffects;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class MissileBoy : Creature
    {
        public MissileBoy() : base("Missile Boy", 3, 1000, Engine.Race.Human, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new MissileBoyEffect());
        }
    }

    class MissileBoyEffect : EachCivilizationCardCostsMoreEffect
    {
        public MissileBoyEffect(EachCivilizationCardCostsMoreEffect effect) : base(effect)
        {
        }

        public MissileBoyEffect(Engine.Civilization civilization = Engine.Civilization.Light) : base(1, civilization)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new MissileBoyEffect(this);
        }
    }
}
