using Engine.Steps;
using System;

namespace Engine.GameEvents
{
    public class CreatureAttackedEvent : GameEvent
    {
        public ICard Attacker { get; }
        private Guid _id;

        public CreatureAttackedEvent(ICard attacker, Guid id)
        {
            Attacker = attacker;
            _id = id;
        }

        public override void Happen(IGame game)
        {
            var phase = game.CurrentTurn.CurrentPhase as AttackPhase;
            phase.SetAttackingCreature(Attacker, game);
            phase.AttackTarget = game.GetAttackable(_id).Id;
        }

        public override string ToString()
        {
            return $"{Attacker} attacked {_id}.";
        }
    }
}
