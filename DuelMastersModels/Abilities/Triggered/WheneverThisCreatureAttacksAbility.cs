using DuelMastersModels.GameEvents;

namespace DuelMastersModels.Abilities.Triggered
{
    public abstract class WheneverThisCreatureAttacksAbility : TriggeredAbility
    {
        protected WheneverThisCreatureAttacksAbility() : base()
        {
        }

        protected WheneverThisCreatureAttacksAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(GameEvent gameEvent, Duel duel)
        {
            return gameEvent is CreatureAttackedEvent e && e.Attacker == SourcePermanent;
        }
    }
}
