using Common.GameEvents;
using Engine;
using Engine.Abilities;
using System;

namespace Cards.TriggeredAbilities
{
    class AfterAttackAbility : TriggeredAbility
    {
        public Guid Attacker { get; }

        public AfterAttackAbility(OneShotEffect effect, Guid attacker) : base(effect)
        {
            Attacker = attacker;
        }

        public AfterAttackAbility(AfterAttackAbility ability) : base(ability)
        {
            Attacker = ability.Attacker;
        }

        public override bool CanTrigger(GameEvent gameEvent, Game game)
        {
            return gameEvent is CreatureStoppedAttackingEvent e && e.Attacker.Id == Attacker;
        }

        public override Ability Copy()
        {
            return new AfterAttackAbility(this);
        }

        public override string ToString()
        {
            return "After the attack";
        }
    }
}
