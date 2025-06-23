using TriggeredAbilities;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

public sealed class ToelVizierOfHope : Creature
{
    public ToelVizierOfHope() : base("Toel, Vizier of Hope", 5, 2000, Race.Initiate, Civilization.Light)
    {
        AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new ToelVizierOfHopeEffect()));
    }
}
