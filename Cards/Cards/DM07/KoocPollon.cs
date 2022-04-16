namespace Cards.Cards.DM07
{
    class KoocPollon : Creature
    {
        public KoocPollon() : base("Kooc Pollon", 2, 1000, Engine.Race.FireBird, Engine.Civilization.Fire)
        {
            AddThisCreatureCannotBeAttackedAbility();
        }
    }
}
