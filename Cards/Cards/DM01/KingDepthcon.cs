namespace Cards.Cards.DM01
{
    class KingDepthcon : Creature
    {
        public KingDepthcon() : base("King Depthcon", 7, 6000, Engine.Subtype.Leviathan, Engine.Civilization.Water)
        {
            AddDoubleBreakerAbility();
            AddThisCreatureCannotBeBlockedAbility();
        }
    }
}
