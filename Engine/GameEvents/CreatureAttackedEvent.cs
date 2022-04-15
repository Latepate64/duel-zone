using Engine.Steps;

namespace Engine.GameEvents
{
    public class CreatureAttackedEvent : GameEvent
    {
        public ICard Attacker { get; }
        public IAttackable Target { get; }

        public CreatureAttackedEvent(ICard attacker, IAttackable id)
        {
            Attacker = attacker;
            Target = id;
        }

        public override void Happen(IGame game)
        {
            var phase = game.CurrentTurn.CurrentPhase as AttackPhase;
            phase.SetAttackingCreature(Attacker);
            phase.AttackTarget = Target;
        }

        public override string ToString()
        {
            return $"{Attacker} attacked {Target}.";
        }
    }
}
