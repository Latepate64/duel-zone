using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM02
{
    sealed class BurstShot : Spell
    {
        public BurstShot() : base("Burst Shot", 6, Civilization.Fire)
        {
            AddShieldTrigger();
            AddSpellAbilities(
                new DestroyAreaOfEffect(
                    filter: new MaxPowerFilter(2000),
                    selectionRange: SelectionRange.AllCards,
                    excludeSource: false));
        }
    }
}
