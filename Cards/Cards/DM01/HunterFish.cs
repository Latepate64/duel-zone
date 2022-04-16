namespace Cards.Cards.DM01
{
    class HunterFish : Creature
    {
        public HunterFish() : base("Hunter Fish", 2, 3000, Engine.Race.Fish, Engine.Civilization.Water)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
