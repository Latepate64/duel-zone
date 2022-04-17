namespace Cards.Cards.DM07
{
    class CuriousEye : Creature
    {
        public CuriousEye() : base("Curious Eye", 3, 1000, Engine.Race.CyberVirus, Engine.Civilization.Water)
        {
            AddWheneverThisCreatureAttacksAbility(new OneShotEffects.YouMayLookAtOneOfYourOpponentsShieldsEffect());
        }
    }
}
