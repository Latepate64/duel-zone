using Cards.ContinuousEffects;
using Cards.StaticAbilities;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

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

        public void AddAbility(IGame game)
        {
            if (!GetController(game).ShieldZone.Cards.Any())
            {
                GetSourceCard(game).AddGrantedAbility(new DoubleBreakerAbility());
            }
        }

        public override IContinuousEffect Copy()
        {
            return new GazariasDragonEffect();
        }

        public void ModifyPower(IGame game)
        {
            if (!GetController(game).ShieldZone.Cards.Any())
            {
                GetSourceCard(game).Power += 4000;
            }
        }

        public override string ToString()
        {
            return "While you have no shields, this creature gets +4000 power and has \"double breaker.\"";
        }
    }
}
