namespace Engine.GameEvents
{
    public class CreatureSummonedEvent : GameEvent
    {
        public CreatureSummonedEvent(IPlayer player, ICard creature)
        {
            Player = player;
            Creature = creature;
        }

        public IPlayer Player { get; }
        public ICard Creature { get; }

        public override void Happen(IGame game)
        {
            _ = game.Move(ZoneType.Hand, ZoneType.BattleZone, Creature);
        }

        public override string ToString()
        {
            return $"{Player} summoned {Creature}.";
        }
    }
}
