using TriggeredAbilities;

namespace Cards.DM01
{
    sealed class Gigargon : Creature
    {
        public Gigargon() : base("Gigargon", 8, 3000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnUpToTwoCreaturesFromYourGraveyardToYourHandEffect()));
        }
    }
}
