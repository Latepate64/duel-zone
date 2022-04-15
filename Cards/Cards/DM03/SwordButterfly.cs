namespace Cards.Cards.DM03
{
    class SwordButterfly : Creature
    {
        public SwordButterfly() : base("Sword Butterfly", 3, 2000, Engine.Subtype.GiantInsect, Engine.Civilization.Nature)
        {
            AddPowerAttackerAbility(3000);
        }
    }
}
