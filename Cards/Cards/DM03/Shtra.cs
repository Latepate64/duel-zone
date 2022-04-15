namespace Cards.Cards.DM03
{
    class Shtra : Creature
    {
        public Shtra() : base("Shtra", 4, 2000, Engine.Subtype.CyberLord, Engine.Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.MutualManaRecoveryEffect(1));
        }
    }
}
