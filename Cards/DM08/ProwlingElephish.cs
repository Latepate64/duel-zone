using Abilities.Static;

namespace Cards.DM08
{
    sealed class ProwlingElephish : Creature
    {
        public ProwlingElephish() : base("Prowling Elephish", 4, 2000, Interfaces.Race.GelFish, Interfaces.Civilization.Water)
        {
            AddAbilities(new BlockerAbility());
        }
    }
}
