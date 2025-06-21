using Interfaces;

namespace Engine.GameEvents
{
    public class CreatureSummonedEvent(Player player, Creature creature) : GameEvent
    {
        public Player Player { get; } = player;
        public Creature Creature { get; } = creature;

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
