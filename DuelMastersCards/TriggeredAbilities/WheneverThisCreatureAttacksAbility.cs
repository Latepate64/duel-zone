using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.GameEvents;

namespace DuelMastersCards.TriggeredAbilities
{
    public class WheneverThisCreatureAttacksAbility : TriggeredAbility
    {
        public WheneverThisCreatureAttacksAbility(OneShotEffect effect) : base(effect)
        {
        }

        public WheneverThisCreatureAttacksAbility(TriggeredAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(GameEvent gameEvent, Game game)
        {
            return gameEvent is CreatureAttackedEvent e && e.Attacker.Id == Source;
        }

        public override Ability Copy()
        {
            return new WheneverThisCreatureAttacksAbility(this);
        }
    }
}
