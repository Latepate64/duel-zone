using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM01;

public class PoisonousMushroom : Creature
{
    public PoisonousMushroom() : base("Poisonous Mushroom", 2, 1000, Race.BalloonMushroom, Civilization.Nature)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PoisonousMushroomEffect()));
    }
}
