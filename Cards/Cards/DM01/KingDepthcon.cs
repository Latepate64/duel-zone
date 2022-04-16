namespace Cards.Cards.DM01
{
    class KingDepthcon : Creature
    {
        public KingDepthcon() : base("King Depthcon", 7, 6000, Engine.Race.Leviathan, Engine.Civilization.Water)
        {
            AddDoubleBreakerAbility();
            AddThisCreatureCannotBeBlockedAbility();
        }
    }
}
