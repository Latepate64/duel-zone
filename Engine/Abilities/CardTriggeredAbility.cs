using Common.GameEvents;

namespace Engine.Abilities
{
    public abstract class CardTriggeredAbility : TriggeredAbility
    {
        public ICardFilter Filter { get; }

        protected CardTriggeredAbility(IOneShotEffect effect) : this(effect, new TargetFilter()) { }

        protected CardTriggeredAbility(IOneShotEffect effect, ICardFilter filter) : base(effect)
        {
            Filter = filter;
        }

        protected CardTriggeredAbility(CardTriggeredAbility ability) : base(ability)
        {
            Filter = ability.Filter.Copy();
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            if (CheckInterveningIfClause(game))
            {
                return gameEvent is CardEvent e && Filter.Applies(game.GetCard(e.Card.Id), game, game.GetPlayer(e.Card.Owner));
            }
            return false;
        }
    }
}
