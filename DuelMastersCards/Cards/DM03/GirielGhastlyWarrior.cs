using Engine;

namespace Cards.Cards.DM03
{
    class GirielGhastlyWarrior : Creature
    {
        public GirielGhastlyWarrior() : base("Giriel, Ghastly Warrior", 8, Civilization.Darkness, 11000, Subtype.DemonCommand)
        {
            Abilities.Add(new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
