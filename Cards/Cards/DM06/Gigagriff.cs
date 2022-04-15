namespace Cards.Cards.DM06
{
    class Gigagriff : Creature
    {
        public Gigagriff() : base("Gigagriff", 6, 4000, Engine.Subtype.Chimera, Engine.Civilization.Darkness)
        {
            AddBlockerAbility();
            AddSlayerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
