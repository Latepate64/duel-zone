using Common;

namespace Cards.Cards.Promo
{
    class Gigagrax : Creature
    {
        public Gigagrax() : base("Gigagrax", 8, 5000, Subtype.Chimera, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsDestroyedAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesEffect()));
        }
    }
}
