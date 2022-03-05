using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using Engine.Durations;

namespace Cards.OneShotEffects
{
    public class DestroyAfterBattleEffect : OneShotEffect
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
            game.DelayedTriggeredAbilities.Add(new DelayedTriggeredAbility(ability, new Once(), source.Source, source.Owner));
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
