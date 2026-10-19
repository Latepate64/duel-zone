using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM03;

public sealed class KingPonitas : Creature
{
    public KingPonitas() : base("King Ponitas", 8, 4000, Race.Leviathan,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new SearchEffect(
                    reveal: true,
                    filter: new CivilizationCardFilter(Civilization.Water)
                )));
    }
}
