using Engine.Steps;
using System;

namespace Engine.GameEvents
{
    public class CreatureAttackedEvent : GameEvent
    {
        private ICard _attacker;
        private Guid _id;

        public CreatureAttackedEvent(ICard attacker, Guid id)
        {
            _attacker = attacker;
            _id = id;
        }

        public override void Happen(IGame game)
        {
            var phase = game.CurrentTurn.CurrentPhase as AttackPhase;
            phase.SetAttackingCreature(_attacker, game);
            phase.AttackTarget = game.GetAttackable(_id).Id;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
