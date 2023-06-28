using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using System;

namespace Cards.Cards.DM12
{
    class Gigavrand : Creature
    {
        public Gigavrand() : base("Gigavrand", 6, 3000, Race.Chimera, Civilization.Darkness)
        {
            AddTriggeredAbility(new GigavrandAbility());
        }
    }

    class GigavrandAbility : LinkedTriggeredAbility, IWatcher
    {
        private int _cardsDrawnByOpponent;

        public GigavrandAbility()
        {
        }

        public GigavrandAbility(GigavrandAbility ability) : base(ability)
        {
            _cardsDrawnByOpponent = ability._cardsDrawnByOpponent;
        }

        public override bool CanTrigger(IGameEvent gameEvent)
        {
            return gameEvent is PhaseBegunEvent e && e.Phase.Type == Engine.Steps.PhaseOrStep.EndOfTurn && ValidInterveningIfClause;
        }

        public override IAbility Copy()
        {
            return new GigavrandAbility(this);
        }

        public override void Resolve()
        {
            if (ValidInterveningIfClause)
            {
                Controller.Opponent.Discard(this, Controller.Opponent.Hand.Cards.ToArray());
            }
        }

        public override string ToString()
        {
            return "At the end of each turn, if your opponent drew 2 or more cards that turn, he discards his hand.";
        }

        public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
        {
            return new GigavrandAbility(this);
        }

        public void Watch(IGame game, IGameEvent gameEvent)
        {
            if (gameEvent is DrawCardEvent e && e.Player == Controller.Opponent)
            {
                ++_cardsDrawnByOpponent;
            }
            else if (gameEvent is PhaseBegunEvent p && p.Phase.Type == Engine.Steps.PhaseOrStep.StartOfTurn)
            {
                _cardsDrawnByOpponent = 0;
            }
        }

        private bool ValidInterveningIfClause => _cardsDrawnByOpponent >= 2;
    }
}
