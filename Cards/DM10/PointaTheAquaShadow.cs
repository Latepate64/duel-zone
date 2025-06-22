using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM10;

public class PointaTheAquaShadow : Creature
{
    public PointaTheAquaShadow() : base(
        "Pointa, the Aqua Shadow", 5, 2000, [Race.LiquidPeople, Race.Ghost], Civilization.Water, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PointaTheAquaShadowEffect()));
    }
}
