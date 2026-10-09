using Abilities.Static;
using ContinuousEffects.PowerModifying;
using ContinuousEffects.Unblockable;

namespace Cards.DM07
{
    sealed class WorldTreeRootOfLife : EvolutionCreature
    {
        public WorldTreeRootOfLife() : base("World Tree, Root of Life", 6, 7000, Interfaces.Race.TreeFolk, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
            AddStaticAbilities(new StealthEffect(Interfaces.Civilization.Darkness));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
