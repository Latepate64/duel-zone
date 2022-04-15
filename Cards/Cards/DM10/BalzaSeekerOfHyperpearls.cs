namespace Cards.Cards.DM10
{
    class BalzaSeekerOfHyperpearls : Creature
    {
        public BalzaSeekerOfHyperpearls() : base("Balza, Seeker of Hyperpearls", 8, 4000, Engine.Subtype.MechaThunder, Common.Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }
}
