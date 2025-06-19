using Abilities.Triggered;

namespace Cards.Cards.DM10
{
    class GajirabuteVileCenturion : Engine.Creature
    {
        public GajirabuteVileCenturion() : base("Gajirabute, Vile Centurion", 6, 3000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
    {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect()));
        }
    }
}
