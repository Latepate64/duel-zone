using ContinuousEffects;

namespace Cards.DM06
{
    class PhantasmalHorrorGigazald : EvolutionCreature
    {
        public PhantasmalHorrorGigazald() : base("Phantasmal Horror Gigazald", 5, 5000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new TapAbilityAddingEffect(Interfaces.Civilization.Darkness, new OneShotEffects.OpponentDiscardsCardAtRandomEffect()));
        }
    }
}
