using Engine.GameEvents;

namespace Engine.Abilities
{
    public abstract class CardTriggeredAbility : TriggeredAbility
    {
        protected CardTriggeredAbility(IOneShotEffect effect) : base(effect)
        {
        }

        protected CardTriggeredAbility(CardTriggeredAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            if (CheckInterveningIfClause(game))
            {
                throw new System.NotImplementedException();
                //return gameEvent is CardEvent e && e.Card != null && TriggersFrom(game.GetCard(e.Card.Id), game);
            }
            return false;
        }

        protected abstract bool TriggersFrom(ICard card, IGame game);
    }
}
