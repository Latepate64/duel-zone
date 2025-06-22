using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class EstolVizierOfAqua : Creature
{
    public EstolVizierOfAqua() : base(
        "Estol, Vizier of Aqua", 5, 2000, [Race.Initiate, Race.LiquidPeople], Civilization.Light, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new EstolVizierOfAquaEffect()));
    }
}
