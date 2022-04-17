namespace Cards.Cards.DM06
{
    class CursedPincher : Creature
    {
        public CursedPincher() : base("Cursed Pincher", 4, 2000, Engine.Race.BrainJacker, Engine.Civilization.Darkness)
        {
            AddBlockerAbility();
            AddSlayerAbility();
            AddThisCreatureCannotAttackAbility();
        }
    }
}
