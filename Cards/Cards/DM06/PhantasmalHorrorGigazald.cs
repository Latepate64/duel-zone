using Cards.ContinuousEffects;

namespace Cards.Cards.DM06
{
    class PhantasmalHorrorGigazald : EvolutionCreature
    {
        public PhantasmalHorrorGigazald() : base("Phantasmal Horror Gigazald", 5, 5000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new TapAbilityAddingEffect(Engine.Civilization.Darkness, new OneShotEffects.OpponentRandomDiscardEffect()));
        }
    }
}
