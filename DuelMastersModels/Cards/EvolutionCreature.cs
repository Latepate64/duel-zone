namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Evolution creature is a creature type.
    /// </summary>
    public abstract class EvolutionCreature : Creature, IEvolutionCreature
    {
        /// <summary>
        /// Creates an evolution creature.
        /// </summary>
        protected EvolutionCreature(int cost, Civilization civilization, int power, Race race) : base(cost, civilization, power, race)
        {
        }
    }
}
