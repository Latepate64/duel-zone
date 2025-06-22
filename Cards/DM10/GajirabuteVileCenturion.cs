using TriggeredAbilities;

namespace Cards.DM10
{
    sealed class GajirabuteVileCenturion : Engine.Creature
    {
        public GajirabuteVileCenturion() : base("Gajirabute, Vile Centurion", 6, 3000, Interfaces.Race.DemonCommand, Interfaces.Civilization.Darkness)
    {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect()));
        }
    }
}
