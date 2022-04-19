using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;

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

        public override void Apply(IGame game, IAbility source)
        {
            game.AddDelayedTriggeredAbility(new DelayedTriggeredAbility(new AfterBattleAbility(new DestroyThisCreatureEffect()), source.Source, source.Controller, true));
        }

        public override IOneShotEffect Copy()
        {
            return new DestroyAfterBattleEffect(this);
        }

        public override string ToString()
        {
            return "Destroy it after the battle.";
        }
    }
}
