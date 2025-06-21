using TriggeredAbilities;

namespace Cards.DM01
{
    class Gigargon : Engine.Creature
    {
        public Gigargon() : base("Gigargon", 8, 3000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnUpToTwoCreaturesFromYourGraveyardToYourHandEffect()));
        }
    }
}
