namespace Cards.Cards.DM10
{
    public class GajirabuteVileCenturion : Creature
    {
        public GajirabuteVileCenturion() : base("Gajirabute, Vile Centurion", 6, 3000, Engine.Race.DemonCommand, Engine.Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseOneOfYourOpponentsShieldsAndPutItIntoHisGraveyardEffect());
        }
    }
}
