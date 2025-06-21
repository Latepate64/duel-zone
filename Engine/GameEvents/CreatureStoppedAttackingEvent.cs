using Engine.Steps;

namespace Engine.GameEvents
{
    public class CreatureStoppedAttackingEvent(ICard card, AttackPhase attackPhase) : GameEvent
    {
        public ICard AttackingCreature { get; } = card;
        public AttackPhase AttackPhase { get; } = attackPhase;

        public override void Happen(IGame game)
        {
            AttackPhase.AttackingCreature = null;
        }

        public override string ToString()
        {
            return $"{AttackingCreature} is no longer attacking.";
        }
    }
}
