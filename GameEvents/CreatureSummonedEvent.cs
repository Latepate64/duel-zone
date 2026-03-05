using Interfaces;

namespace GameEvents
{
    public sealed class CreatureSummonedEvent(IPlayer player, ICreature creature) : GameEvent
    {
        public IPlayer Player { get; } = player;
        public ICreature Creature { get; } = creature;

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
