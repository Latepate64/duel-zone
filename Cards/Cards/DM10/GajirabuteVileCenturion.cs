using Cards.TriggeredAbilities;

namespace Cards.Cards.DM10
{
    class GajirabuteVileCenturion : Creature
    {
        public GajirabuteVileCenturion() : base("Gajirabute, Vile Centurion", 6, 3000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
    {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect()));
        }
    }
}
