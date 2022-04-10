namespace Engine.GameEvents
{
    class ShuffleDeckEvent : GameEvent
    {
        private readonly IPlayer _player;

        public ShuffleDeckEvent(IPlayer player)
        {
            _player = player;
        }

        public override void Happen(IGame game)
        {
            _player.Deck.Shuffle();
        }

        public override string ToString()
        {
            return $"{_player} shuffled their deck.";
        }
    }
}
