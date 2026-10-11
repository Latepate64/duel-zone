using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

sealed class Teleportation : Spell
{
    public Teleportation() : base("Teleportation", 5, Civilization.Water)
    {
        AddSpellAbilities(
            new ChooseAndReturnCreaturesToTheirOwnersHandsEffect(
                0, 2, new CreatureFilter()
        ));
    }
}