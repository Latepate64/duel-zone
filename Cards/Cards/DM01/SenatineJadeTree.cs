namespace Cards.Cards.DM01
{
    class SenatineJadeTree : Creature
    {
        public SenatineJadeTree() : base("Senatine Jade Tree", 3, 4000, Engine.Subtype.StarlightTree, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
