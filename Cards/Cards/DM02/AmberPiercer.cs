using Cards.TriggeredAbilities;

namespace Cards.Cards.DM02
{
    class AmberPiercer : Engine.Creature
    {
        public AmberPiercer() : base("Amber Piercer", 4, 2000, Engine.Race.BrainJacker, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayReturnCreatureFromYourGraveyardToYourHandEffect()));
        }
    }
}