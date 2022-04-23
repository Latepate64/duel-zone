namespace Engine.GameEvents
{
    public class EvolutionEvent : GameEvent
    {
        public EvolutionEvent(IPlayer player, ICard card, ICard bait)
        {
            Player = player;
            EvolutionCreature = card;
            Bait = bait;
        }

        public IPlayer Player { get; }
        public ICard EvolutionCreature { get; }
        public ICard Bait { get; }

        public override void Happen(IGame game)
        {
            EvolutionCreature.PutOnTopOf(Bait);
        }

        public override string ToString()
        {
            return $"{Player} evolved {Bait} into {EvolutionCreature}.";
        }
    }
}
