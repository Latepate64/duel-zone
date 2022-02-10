namespace Cards.Cards.DM03
{
    class GirielGhastlyWarrior : Creature
    {
        public GirielGhastlyWarrior() : base("Giriel, Ghastly Warrior", 8, Common.Civilization.Darkness, 11000, Common.Subtype.DemonCommand)
        {
            Abilities.Add(new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
