namespace Common.GameEvents
{
    public abstract class CardEvent : GameEvent, ICardEvent
    {
        /// <summary>
        /// The card the event is relative to (eg. card is used, card attacks etc.)
        /// </summary>
        public ICard Card { get; set; }

        protected CardEvent()
        {
        }

        protected CardEvent(ICardEvent e)
        {
            Card = e.Card;
        }
    }
}
