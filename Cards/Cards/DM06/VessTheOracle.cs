namespace Cards.Cards.DM06
{
    class VessTheOracle : Creature
    {
        public VessTheOracle() : base("Vess, the Oracle", 1, 2000, Engine.Subtype.LightBringer, Common.Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
