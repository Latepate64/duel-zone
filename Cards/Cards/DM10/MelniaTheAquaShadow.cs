namespace Cards.Cards.DM10
{
    class MelniaTheAquaShadow : Creature
    {
        public MelniaTheAquaShadow() : base("Melnia, the Aqua Shadow", 2, 1000, Engine.Subtype.LiquidPeople, Engine.Subtype.Ghost, Engine.Civilization.Water, Engine.Civilization.Darkness)
        {
            AddThisCreatureCannotBeBlockedAbility();
            AddSlayerAbility();
        }
    }
}
