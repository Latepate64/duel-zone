namespace Cards.Cards.DM01
{
    class SzubsKinTwilightGuardian : Creature
    {
        public SzubsKinTwilightGuardian() : base("Szubs Kin, Twilight Guardian", 5, 6000, Common.Subtype.Guardian, Common.Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
