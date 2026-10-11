using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM11;

public sealed class SpinningTerrorTheWretched : Creature
{
    public SpinningTerrorTheWretched() : base("Spinning Terror, the Wretched",
        2, 1000, Race.DevilMask, Civilization.Darkness)
    {
        AddStaticAbilities(
            new ThisCreatureGetPowerForEachCreatureYourOpponentControls(
                2000, new TappedCreatureFilter()));
    }
}
