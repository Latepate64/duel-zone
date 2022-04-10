﻿using Engine;
using Engine.Abilities;
using Engine.GameEvents;

namespace Cards.TriggeredAbilities
{
    class WhenThisCreatureAttacksPlayerAbility : WheneverThisCreatureAttacksAbility
    {
        public WhenThisCreatureAttacksPlayerAbility(IOneShotEffect effect) : base(effect)
        {
        }

        public WhenThisCreatureAttacksPlayerAbility(WheneverThisCreatureAttacksAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            throw new System.NotImplementedException();
            //return base.CanTrigger(gameEvent, game) && gameEvent is CreatureAttackedEvent e && e.Attackable == game.GetOpponent(Controller);
        }

        public override IAbility Copy()
        {
            return new WhenThisCreatureAttacksPlayerAbility(this);
        }

        public override string ToString()
        {
            return $"When this creature attacks a player, {GetEffectText()}";
        }
    }
}
