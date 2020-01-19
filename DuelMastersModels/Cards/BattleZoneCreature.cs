namespace DuelMastersModels.Cards
{
    public class BattleZoneCreature : Creature, IBattleZoneCreature
    {
        internal BattleZoneCreature(IZoneCreature creature) : base(creature.Name, creature.CardSet, creature.Id, creature.Civilizations, creature.Rarity, creature.Cost, creature.Text, creature.Flavor, creature.Illustrator, creature.Power, creature.Races)
        {
        }

        public bool Tapped { get; internal set; }
    }
}
