using Common;

namespace Cards.Cards.DM06
{
    class PhantasmalHorrorGigazald : Creature
    {
        public PhantasmalHorrorGigazald() : base("Phantasmal Horror Gigazald", 5, 5000, Subtype.Chimera, Civilization.Darkness)
        {
            AddAbilities(new StaticAbilities.TapAbilityAddingAbility(Civilization.Darkness, new OneShotEffects.OpponentRandomDiscardEffect()));
        }
    }
}
