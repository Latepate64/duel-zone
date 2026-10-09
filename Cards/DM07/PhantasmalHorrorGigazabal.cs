using Abilities.Static;
using ContinuousEffects.Unblockable;

namespace Cards.DM07
{
    sealed class PhantasmalHorrorGigazabal : EvolutionCreature
    {
        public PhantasmalHorrorGigazabal() : base("Phantasmal Horror Gigazabal", 5, 9000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new StealthEffect(Interfaces.Civilization.Light));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
