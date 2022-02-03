namespace Cards.Cards.DM02
{
    class SilverFist : Creature
    {
        public SilverFist() : base("Silver Fist", 4, Common.Civilization.Nature, 3000, Common.Subtype.BeastFolk)
        {
            Abilities.Add(new StaticAbilities.PowerAttackerAbility(2000));
        }
    }
}
