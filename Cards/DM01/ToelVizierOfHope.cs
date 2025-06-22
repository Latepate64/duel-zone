using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM01;

public class ToelVizierOfHope : Creature
{
    public ToelVizierOfHope() : base("Toel, Vizier of Hope", 5, 2000, Race.Initiate, Civilization.Light)
    {
        AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new ToelVizierOfHopeEffect()));
    }
}
