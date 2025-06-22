using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM03;

public sealed class AquaDeformer : Creature
{
    public AquaDeformer() : base("Aqua Deformer", 8, 3000, Race.LiquidPeople, Civilization.Water)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new AquaDeformerEffect()));
    }
}
