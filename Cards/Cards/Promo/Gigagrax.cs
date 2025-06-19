using Abilities.Triggered;
using Abilities.Triggered;

namespace Cards.Cards.Promo
{
    class Gigagrax : Engine.Creature
    {
        public Gigagrax() : base("Gigagrax", 8, 5000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OneShotEffects.YouMayDestroyOneOfYourOpponentsCreaturesEffect()));
        }
    }
}
