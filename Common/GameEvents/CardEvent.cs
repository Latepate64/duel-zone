namespace Common.GameEvents
{
    public abstract class CardEvent : GameEvent
    {
        /// <summary>
        /// The card the event is relative to (eg. card is used, card attacks etc.)
        /// </summary>
        public ICard Card { get; set; }

        protected CardEvent()
        {
        }

        protected CardEvent(CardEvent e)
        {
            Card = e.Card;
        }
    }
}
