using TriggeredAbilities;

namespace Cards.DM02
{
    class AmberPiercer : Engine.Creature
    {
        public AmberPiercer() : base("Amber Piercer", 4, 2000, Interfaces.Race.BrainJacker, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayReturnCreatureFromYourGraveyardToYourHandEffect()));
        }
    }
}