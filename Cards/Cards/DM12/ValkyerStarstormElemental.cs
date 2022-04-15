namespace Cards.Cards.DM12
{
    class ValkyerStarstormElemental : Creature
    {
        public ValkyerStarstormElemental() : base("Valkyer, Starstorm Elemental", 5, 7000, Engine.Subtype.AngelCommand, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
