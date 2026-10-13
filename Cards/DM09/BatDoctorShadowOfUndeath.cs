using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM09;

public sealed class BatDoctorShadowOfUndeath : Creature
{
    public BatDoctorShadowOfUndeath() : base(
        "Bat Doctor, Shadow of Undeath", 3, 2000, Race.Ghost,
            Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenThisCreatureIsDestroyedAbility(
                new SalvageEffect(
                    minimum: 0,
                    maximum: 1,
                    filter: new CreatureFilter(),
                    excludeSource: true,
                    selectionRange: SelectionRange.OwnCreatures
        )));
    }
}
