using Abilities;
using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class ChenTregVizierOfBlades : Creature
{
    public ChenTregVizierOfBlades() : base("Chen Treg, Vizier of Blades", 5,
        2000, Race.Initiate, Civilization.Light)
    {
        AddAbilities(
            new TapAbility(
                new TapChoiceEffect(
                    minimum: 1,
                    maximum: 1,
                    ownerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OpponentsCreatures
                )));
    }
}