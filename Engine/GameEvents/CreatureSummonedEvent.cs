namespace Engine.GameEvents
{
    public class CreatureSummonedEvent(IPlayer player, Card creature) : GameEvent
    {
        public IPlayer Player { get; } = player;
        public Card Creature { get; } = creature;

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
