using Cards.ContinuousEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM07
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

        public void AddAbility()
        {
            if (!Applier.ShieldZone.HasCards)
            {
                Source.AddGrantedAbility(new DoubleBreakerAbility());
            }
        }

        public override IContinuousEffect Copy()
        {
            return new GazariasDragonEffect();
        }

        public void ModifyPower()
        {
            if (!Applier.ShieldZone.HasCards)
            {
                Source.Power += 4000;
            }
        }

        public override string ToString()
        {
            return "While you have no shields, this creature gets +4000 power and has \"double breaker.\"";
        }
    }
}
