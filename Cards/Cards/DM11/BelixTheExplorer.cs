namespace Cards.Cards.DM11
{
    class BelixTheExplorer : Creature
    {
        public BelixTheExplorer() : base("Belix, the Explorer", 2, 3000, Engine.Subtype.Gladiator, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ReturnSpellFromYourManaZoneToYourHandEffect());
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
