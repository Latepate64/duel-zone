namespace Cards.Cards.DM01
{
    class PhantomFish : Creature
    {
        public PhantomFish() : base("Phantom Fish", 3, 4000, Engine.Subtype.GelFish, Engine.Civilization.Water)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
