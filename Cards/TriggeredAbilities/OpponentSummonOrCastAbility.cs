﻿using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.TriggeredAbilities
{
    class OpponentSummonOrCastAbility : TriggeredAbility
    {
        public OpponentSummonOrCastAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public OpponentSummonOrCastAbility(OpponentSummonOrCastAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is CreatureSummonedEvent summon && summon.Player == Controller.Opponent || gameEvent is SpellCastEvent cast && cast.Player == Controller.Opponent;
        }

        public override IAbility Copy()
        {
            return new OpponentSummonOrCastAbility(this);
        }

        public override string ToString()
        {
            return $"When your opponent summons a creature or casts a spell, {GetEffectText()}";
        }
    }
}