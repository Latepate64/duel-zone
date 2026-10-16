using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM04;

public sealed class SwordOfMalevolentDeath : Spell
{
    public SwordOfMalevolentDeath() : base("Sword of Malevolent Death", 4,
        Civilization.Darkness)
    {
        AddSpellAbilities(
            new SwordOfMalevolentDeathOneShotEffect(
                new CreatureFilter(),
                1000,
                new CivilizationCardFilter(Civilization.Darkness),
                new SwordOfMalevolentDeathContinuousEffectFactory()
            ));
    }
}
