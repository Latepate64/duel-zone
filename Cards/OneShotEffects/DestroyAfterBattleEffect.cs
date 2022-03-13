using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using Engine.Durations;

namespace Cards.OneShotEffects
{
    class DestroyAfterBattleEffect : OneShotEffect
    {
        public DestroyAfterBattleEffect()
        {
        }

        public DestroyAfterBattleEffect(DestroyAfterBattleEffect effect)
        {
        }

        public override void Apply(Game game, Ability source)
        {
            var ability = new AfterBattleAbility(new DestroyAreaOfEffect((source as CardTriggeredAbility).Filter));
            game.AddDelayedTriggeredAbility(ability, new Once());
        }

        public override OneShotEffect Copy()
        {
            return new DestroyAfterBattleEffect(this);
        }

        public override string ToString()
        {
            return $"Destroy it after the battle.";
        }
    }
}
