using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM03;

public sealed class KingNeptas : Creature
{
    public KingNeptas() : base("King Neptas", 6, 5000, Race.Leviathan,
        Civilization.Water)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new ChooseAndReturnCreaturesToTheirOwnersHandsEffect(
                    0, 1, new MaxPowerFilter(2000)
                )));
    }
}
