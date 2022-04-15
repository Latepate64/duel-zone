namespace Cards.Cards.DM12
{
    class RadioactiveHornTheStrange : Creature
    {
        public RadioactiveHornTheStrange() : base("Radioactive Horn, the Strange", 3, 1000, Engine.Subtype.HornedBeast, Engine.Civilization.Nature)
        {
            AddDoubleBreakerAbility();
        }
    }
}
