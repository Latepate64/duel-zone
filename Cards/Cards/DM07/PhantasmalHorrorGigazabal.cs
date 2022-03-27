using Common;

namespace Cards.Cards.DM07
{
    class PhantasmalHorrorGigazabal : EvolutionCreature
    {
        public PhantasmalHorrorGigazabal() : base("Phantasmal Horror Gigazabal", 5, 9000, Subtype.Chimera, Civilization.Darkness)
        {
            AddAbilities(new StaticAbilities.StealthAbility(Civilization.Light), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
