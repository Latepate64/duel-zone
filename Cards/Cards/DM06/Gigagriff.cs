namespace Cards.Cards.DM06
{
    class Gigagriff : Creature
    {
        public Gigagriff() : base("Gigagriff", 6, 4000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddBlockerAbility();
            AddSlayerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
