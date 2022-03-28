namespace Cards.Cards.DM02
{
    class Gigastand : Creature
    {
        public Gigastand() : base("Gigastand", 4, 3000, Common.Subtype.Chimera, Common.Civilization.Darkness)
        {
            AddAbilities(new StaticAbilities.GigastandAbility());
        }
    }
}
