namespace Cards.Cards.DM06
{
    class Zepimeteus : Creature
    {
        public Zepimeteus() : base("Zepimeteus", 1, 2000, Engine.Subtype.SeaHacker, Common.Civilization.Water)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
