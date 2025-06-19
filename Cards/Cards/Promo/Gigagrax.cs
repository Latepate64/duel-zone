using Cards.TriggeredAbilities;

namespace Cards.Cards.Promo
{
    class Gigagrax : Creature
    {
        public Gigagrax() : base("Gigagrax", 8, 5000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesEffect()));
        }
    }
}
