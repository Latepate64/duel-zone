using Abilities;
using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class BroodShell : Creature
{
    public BroodShell() : base("Brood Shell", 4, 3000, Race.ColonyBeetle,
        Civilization.Nature)
    {
        AddAbilities(
            new TapAbility(
                new ManaRecoveryEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new CreatureFilter(),
                ownMana: true
        )));
    }
}