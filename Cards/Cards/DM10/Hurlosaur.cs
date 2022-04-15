namespace Cards.Cards.DM10
{
    class Hurlosaur : Creature
    {
        public Hurlosaur() : base("Hurlosaur", 6, 2000, Engine.Subtype.RockBeast, Engine.Civilization.Fire)
        {
            AddShieldTrigger();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(1000));
        }
    }
}
