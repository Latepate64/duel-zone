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
            var ability = GetSourceAbility(game);
            if (!game.BattleZone.GetCreatures(ability.Controller).Any(x => x.Id != ability.Source))
            {
                GetSourceCard(game).AddGrantedAbility(new PowerAttackerAbility(4000));
                GetSourceCard(game).AddGrantedAbility(new DoubleBreakerAbility());
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
