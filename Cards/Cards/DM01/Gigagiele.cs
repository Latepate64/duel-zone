namespace Cards.Cards.DM01
{
    class Gigagiele : Creature
    {
        public Gigagiele() : base("Gigagiele", 5, 3000, Engine.Subtype.Chimera, Engine.Civilization.Darkness)
        {
            AddSlayerAbility();
        }
    }
}
