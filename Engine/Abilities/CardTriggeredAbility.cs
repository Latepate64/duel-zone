using Common.GameEvents;

namespace Engine.Abilities
{
    public abstract class CardTriggeredAbility : TriggeredAbility
    {
        public CardFilter Filter { get; }

        protected CardTriggeredAbility(OneShotEffect effect) : this(effect, new TargetFilter()) { }

        protected CardTriggeredAbility(OneShotEffect effect, CardFilter filter) : base(effect)
        {
            Filter = filter;
        }

        protected CardTriggeredAbility(CardTriggeredAbility ability) : base(ability)
        {
            Filter = ability.Filter.Copy();
        }

        public override bool CanTrigger(GameEvent gameEvent, Game game)
        {
            return CheckInterveningIfClause(game) && gameEvent is CardEvent e && Filter.Applies(game.GetCard(e.Card.Id), game, game.GetPlayer(e.Card.Owner));
        }
    }
}
