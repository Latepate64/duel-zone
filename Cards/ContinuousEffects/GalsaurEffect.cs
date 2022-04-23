using Cards.StaticAbilities;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class GalsaurEffect : ContinuousEffect, IAbilityAddingEffect
    {
        public GalsaurEffect() : base()
        {
        }

        public void AddAbility(IGame game)
        {
            var ability = Ability;
            if (!game.BattleZone.GetCreatures(ability.ControllerPlayer.Id).Any(x => x != ability.Source))
            {
                Source.AddGrantedAbility(new PowerAttackerAbility(4000));
                Source.AddGrantedAbility(new DoubleBreakerAbility());
            }
        }

        public override IContinuousEffect Copy()
        {
            return new GalsaurEffect();
        }

        public override string ToString()
        {
            return "While you have no other creatures in the battle zone, this creature has \"power attacker +4000\" and \"double breaker.\"";
        }
    }
}
