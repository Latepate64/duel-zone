namespace Cards.Cards.DM01
{
    class DarkRavenShadowOfGrief : Creature
    {
        public DarkRavenShadowOfGrief() : base("Dark Raven, Shadow of Grief", 4, 1000, Common.Subtype.Ghost, Common.Civilization.Darkness)
        {
            AddBlockerAbility();
        }
    }
}
