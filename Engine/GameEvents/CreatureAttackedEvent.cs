using Engine.Steps;
using System;

namespace Engine.GameEvents
{
    public class CreatureAttackedEvent : GameEvent
    {
        public ICard Attacker { get; }
        public Guid Target { get; }

        public CreatureAttackedEvent(ICard attacker, Guid id)
        {
            Attacker = attacker;
            Target = id;
        }

        public override void Happen(IGame game)
        {
            var phase = game.CurrentTurn.CurrentPhase as AttackPhase;
            phase.SetAttackingCreature(Attacker, game);
            phase.AttackTarget = game.GetAttackable(Target).Id;
        }

        public override string ToString()
        {
            return $"{Attacker} attacked {Target}.";
        }
    }
}
