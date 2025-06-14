namespace Engine.GameEvents
{
    public class CreatureSummonedEvent : GameEvent
    {
        public CreatureSummonedEvent(IPlayer player, Card creature)
        {
            Player = player;
            Creature = creature;
        }

        public IPlayer Player { get; }
        public Card Creature { get; }

        public override void Happen(IGame game)
        {
            _ = game.Move(null, ZoneType.Hand, ZoneType.BattleZone, Creature);
        }

        public override string ToString()
        {
            return $"{Player} summoned {Creature}.";
        }
    }
}
