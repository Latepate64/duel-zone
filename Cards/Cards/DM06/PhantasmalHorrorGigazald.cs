using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM06
{
    class PhantasmalHorrorGigazald : EvolutionCreature
    {
        public PhantasmalHorrorGigazald() : base("Phantasmal Horror Gigazald", 5, 5000, Subtype.Chimera, Civilization.Darkness)
        {
            AddStaticAbilities(new TapAbilityAddingEffect(Civilization.Darkness, new OneShotEffects.OpponentRandomDiscardEffect()));
        }
    }
}
