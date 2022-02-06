using Common.GameEvents;
using Engine;
using Engine.Abilities;

namespace Cards.TriggeredAbilities
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
            return gameEvent is CreatureAttackedEvent e && e.Attacker.Id == Source && CheckInterveningIfClause(game);
        }

        public override Ability Copy()
        {
            return new WheneverThisCreatureAttacksAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever this creature attacks, {OneShotEffect}";
        }
    }
}
