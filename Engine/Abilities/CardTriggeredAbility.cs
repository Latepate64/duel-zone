using Common.GameEvents;

namespace Engine.Abilities
{
    public abstract class CardTriggeredAbility : TriggeredAbility
    {
        public CardFilter Filter { get; }

        protected CardTriggeredAbility(IOneShotEffect effect) : this(effect, new TargetFilter()) { }

        protected CardTriggeredAbility(IOneShotEffect effect, CardFilter filter) : base(effect)
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
                bool foo = gameEvent is CardEvent e;
                return foo;
            }
            return false;
            //return CheckInterveningIfClause(game) && gameEvent is CardEvent e && Filter.Applies(game.GetCard(e.Card.Id), game, game.GetPlayer(e.Card.Owner));
        }
    }
}
