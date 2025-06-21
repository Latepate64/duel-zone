using ContinuousEffects;

namespace Cards.DM07
{
    class PhantasmalHorrorGigazabal : EvolutionCreature
    {
        public PhantasmalHorrorGigazabal() : base("Phantasmal Horror Gigazabal", 5, 9000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new StealthEffect(Interfaces.Civilization.Light));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
