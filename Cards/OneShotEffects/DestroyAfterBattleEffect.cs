﻿using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class DestroyAfterBattleEffect : OneShotEffect
    {
        public DestroyAfterBattleEffect()
        {
        }

        public DestroyAfterBattleEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            game.AddDelayedTriggeredAbility(new AfterBattleDelayedTriggeredAbility(new DestroyThisCreatureEffect(), Ability));
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
