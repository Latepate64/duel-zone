using TriggeredAbilities;

namespace Cards.DM01
{
    class Gigargon : Engine.Creature
    {
        public Gigargon() : base("Gigargon", 8, 3000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnUpToTwoCreaturesFromYourGraveyardToYourHandEffect()));
        }
    }
}
