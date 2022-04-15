using Engine.Steps;
using System;

namespace Engine.GameEvents
{
    public class CreatureStoppedAttackingEvent : GameEvent
    {
        public CreatureStoppedAttackingEvent(ICard card, AttackPhase attackPhase)
        {
            AttackingCreature = card;
            AttackPhase = attackPhase;
        }

        public ICard AttackingCreature { get; }
        public AttackPhase AttackPhase { get; }

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
