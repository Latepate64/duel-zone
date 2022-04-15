using Cards.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class PhantasmalHorrorGigazabal : EvolutionCreature
    {
        public PhantasmalHorrorGigazabal() : base("Phantasmal Horror Gigazabal", 5, 9000, Engine.Subtype.Chimera, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new StealthEffect(Engine.Civilization.Light));
            AddDoubleBreakerAbility();
        }
    }
}
