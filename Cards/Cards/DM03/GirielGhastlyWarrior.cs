namespace Cards.Cards.DM03
{
    class GirielGhastlyWarrior : Creature
    {
        public GirielGhastlyWarrior() : base("Giriel, Ghastly Warrior", 8, 11000, Common.Subtype.DemonCommand, Common.Civilization.Darkness)
        {
            Abilities.Add(new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
