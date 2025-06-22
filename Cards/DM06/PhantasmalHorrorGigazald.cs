using ContinuousEffects;
using OneShotEffects;

namespace Cards.DM06
{
    sealed class PhantasmalHorrorGigazald : EvolutionCreature
    {
        public PhantasmalHorrorGigazald() : base("Phantasmal Horror Gigazald", 5, 5000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new TapAbilityAddingEffect(Interfaces.Civilization.Darkness, new OpponentRandomDiscardEffect()));
        }
    }
}
