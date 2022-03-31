using Common;

namespace Cards.Cards.DM09
{
    class StallobTheLifequasher : Creature
    {
        public StallobTheLifequasher() : base("Stallob, the Lifequasher", 8, 6000, Subtype.DemonCommand, Civilization.Darkness)
        {
            AddDoubleBreakerAbility();
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.DestroyAllCreaturesEffect());
        }
    }
}
