using TriggeredAbilities;

namespace Cards.Promo
{
    sealed class Gigagrax : Engine.Creature
    {
        public Gigagrax() : base("Gigagrax", 8, 5000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesEffect()));
        }
    }
}
