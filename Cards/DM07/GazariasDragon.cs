using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.DM07
{
    class GazariasDragon : Creature
    {
        public GazariasDragon() : base("Gazarias Dragon", 5, 4000, Race.ArmoredDragon, Civilization.Fire)
        {
            AddStaticAbilities(new GazariasDragonEffect());
        }
    }

    class GazariasDragonEffect : ContinuousEffect, IPowerModifyingEffect, IAbilityAddingEffect
    {
        public GazariasDragonEffect()
        {
        }

        public GazariasDragonEffect(GazariasDragonEffect effect) : base(effect)
        {
        }

        public void AddAbility(IGame game)
        {
            if (!Controller.ShieldZone.HasCards)
            {
                Source.AddGrantedAbility(new StaticAbility(new DoubleBreakerEffect()));
            }
        }

        public override IContinuousEffect Copy()
        {
            return new GazariasDragonEffect();
        }

        public void ModifyPower(IGame game)
        {
            if (!Controller.ShieldZone.HasCards)
            {
                (Source as Creature).IncreasePower(4000);
            }
        }

        public override string ToString()
        {
            return "While you have no shields, this creature gets +4000 power and has \"double breaker.\"";
        }
    }
}
