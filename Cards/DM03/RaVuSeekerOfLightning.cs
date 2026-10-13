using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM03;

public sealed class RaVuSeekerOfLightning : Creature
{
    public RaVuSeekerOfLightning() : base("Ra Vu, Seeker of Lightning", 6, 4000,
        Race.MechaThunder, Civilization.Light)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new SalvageEffect(
                    minimum: 0,
                    maximum: 1,
                    filter: new MultiFilter(
                        new CivilizationCardFilter(Civilization.Light),
                        new SpellFilter()
                    ),
                    excludeSource: false,
                    selectionRange: SelectionRange.OwnCreatures
        )));
    }
}
