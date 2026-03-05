using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class PointaTheAquaShadow : Creature
{
    public PointaTheAquaShadow() : base(
        "Pointa, the Aqua Shadow", 5, 2000, [Race.LiquidPeople, Race.Ghost], Civilization.Water, Civilization.Darkness)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PointaTheAquaShadowEffect()));
    }
}
