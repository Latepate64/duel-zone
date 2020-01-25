namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Represents a creature that exists in battle zone.
    /// </summary>
    public class BattleZoneCreature : Creature, IBattleZoneCreature// where TCreature : IZoneCreature
    {
        internal BattleZoneCreature(ICreature creature) : base(creature.Name, creature.CardSet, creature.Id, creature.Civilizations, creature.Rarity, creature.Cost, creature.Text, creature.Flavor, creature.Illustrator, creature.Power, creature.Races)
        {
        }

        /// <summary>
        /// Determines whether the creature is tapped or untapped.
        /// </summary>
        public bool Tapped { get; internal set; }
    }
}
