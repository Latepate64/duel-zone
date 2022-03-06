using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class CreepingPlague : Spell
    {
        public CreepingPlague() : base("Creeping Plague", 1, Common.Civilization.Darkness)
        {
            // Whenever any of your creatures becomes blocked this turn, it gets "slayer" until the end of the turn. (When a creature that has "slayer" loses a battle, destroy the other creature.)
            AddAbilities(new SpellAbility(new OneShotEffects.CreepingPlagueEffect()));
        }
    }
}
