using Engine.Steps;

namespace Engine.GameEvents
{
    public class CreatureAttackedEvent(Creature attacker, IAttackable id) : GameEvent
    {
        public Creature Attacker { get; } = attacker;
        public IAttackable Target { get; } = id;

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
