namespace Cards.Cards.DM03
{
    class StingerBall : Creature
    {
        public StingerBall() : base("Stinger Ball", 3, 1000, Engine.Race.CyberVirus, Engine.Civilization.Water)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayLookAtOneOfYourOpponentsShieldsEffect());
        }
    }
}
