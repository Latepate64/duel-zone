namespace Cards.Cards.DM10
{
    class ArdentLunatron : Creature
    {
        public ArdentLunatron() : base("Ardent Lunatron", 3, 5000, Engine.Race.CyberMoon, Engine.Civilization.Water)
        {
            AddBlockerAbility();
            AddThisCreatureBlocksIfAble();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
