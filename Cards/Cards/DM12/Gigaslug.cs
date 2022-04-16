namespace Cards.Cards.DM12
{
    class Gigaslug : Creature
    {
        public Gigaslug() : base("Gigaslug", 3, 1000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddBlockerAbility();
            AddSlayerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
