using Common;

namespace Cards.Cards.DM07
{
    class OtherworldlyWarriorNaglu : Creature
    {
        public OtherworldlyWarriorNaglu() : base("Otherworldly Warrior Naglu", 6, 4000, Subtype.Armorloid, Civilization.Fire)
        {
            AddAbilities(new StaticAbilities.ThisCreatureCannotBeAttackedAbility(), new StaticAbilities.PowerAttackerAbility(3000), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
