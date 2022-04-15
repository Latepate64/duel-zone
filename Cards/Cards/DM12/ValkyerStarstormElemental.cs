namespace Cards.Cards.DM12
{
    class ValkyerStarstormElemental : Creature
    {
        public ValkyerStarstormElemental() : base("Valkyer, Starstorm Elemental", 5, 7000, Engine.Subtype.AngelCommand, Common.Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
