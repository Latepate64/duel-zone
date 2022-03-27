using Engine;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    class GalsaurAbility : Engine.Abilities.StaticAbility
    {
        public GalsaurAbility() : base(new GalsaurEffect())
        {
        }
    }

    class GalsaurEffect : AbilityAddingEffect
    {
        public GalsaurEffect() : base(new TargetFilter(), new Durations.Indefinite(), new Conditions.FilterNoneCondition(new CardFilters.OwnersOtherBattleZoneCreatureFilter()), new PowerAttackerAbility(4000), new DoubleBreakerAbility())
        {
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
