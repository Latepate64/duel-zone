using ContinuousEffects;

namespace Cards.DM07
{
    sealed class OtherworldlyWarriorNaglu : Engine.Creature
    {
        public OtherworldlyWarriorNaglu() : base("Otherworldly Warrior Naglu", 6, 4000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedEffect());
            AddStaticAbilities(new PowerAttackerEffect(3000));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
