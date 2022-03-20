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

        public override object Apply(IGame game, IAbility source)
        {
            var ability = new AfterBattleAbility(new DestroyAreaOfEffect((source as CardTriggeredAbility).Filter));
            game.AddDelayedTriggeredAbility(ability, new Once());
            return null;
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
