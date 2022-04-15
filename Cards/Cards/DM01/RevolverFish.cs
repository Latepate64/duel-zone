namespace Cards.Cards.DM01
{
    class RevolverFish : Creature
    {
        public RevolverFish() : base("Revolver Fish", 4, 5000, Engine.Subtype.GelFish, Engine.Civilization.Water)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
