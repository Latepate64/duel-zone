using TriggeredAbilities;

namespace Cards.DM02
{
    class PhalEegaDawnGuardian : Engine.Creature
    {
        public PhalEegaDawnGuardian() : base("Phal Eega, Dawn Guardian", 5, 4000, Interfaces.Race.Guardian, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayReturnSpellFromYourGraveyardToYourHandEffect()));
        }
    }
}
