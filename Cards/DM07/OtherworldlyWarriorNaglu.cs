using StaticAbilities;
using ContinuousEffects;
using ContinuousEffects.PowerModifying;
using CardFilters;

namespace Cards.DM07
{
    sealed class OtherworldlyWarriorNaglu : Creature
    {
        public OtherworldlyWarriorNaglu() : base("Otherworldly Warrior Naglu", 6, 4000, Interfaces.Race.Armorloid, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedEffect(new CreatureFilter()));
            AddStaticAbilities(new PowerAttackerEffect(3000));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
