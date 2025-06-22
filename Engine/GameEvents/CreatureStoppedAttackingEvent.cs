using Engine.Steps;
using Interfaces;

namespace Engine.GameEvents
{
    public sealed class CreatureStoppedAttackingEvent(ICard card, AttackPhase attackPhase) : GameEvent
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
