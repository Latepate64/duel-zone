using TriggeredAbilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

public sealed class AquaMaster : Creature
{
    public AquaMaster() : base("Aqua Master", 6, 4000, Race.LiquidPeople, Civilization.Water)
    {
        AddTriggeredAbility(new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(
            new AquaMasterEffect()));
    }
}
