using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    class CreepingPlague : Spell
    {
        public CreepingPlague() : base("Creeping Plague", 1, Civilization.Darkness)
        {
            // Whenever any of your creatures becomes blocked this turn, it gets "slayer" until the end of the turn. (When a creature that has "slayer" loses a battle, destroy the other creature.)
            Abilities.Add(new SpellAbility(new OneShotEffects.CreepingPlagueEffect()));
        }
    }
}
