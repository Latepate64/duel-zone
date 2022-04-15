namespace Cards.Cards.DM06
{
    class VessTheOracle : Creature
    {
        public VessTheOracle() : base("Vess, the Oracle", 1, 2000, Engine.Subtype.LightBringer, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
