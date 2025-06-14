using Engine.Steps;

namespace Engine.GameEvents
{
    public class CreatureAttackedEvent(Card attacker, IAttackable id) : GameEvent
    {
        public Card Attacker { get; } = attacker;
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
