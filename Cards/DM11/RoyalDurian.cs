using TriggeredAbilities;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

public sealed class RoyalDurian : Creature
{
    public RoyalDurian() : base("Royal Durian", 5, 1000, Race.WildVeggies, Civilization.Nature)
    {
        AddShieldTrigger();
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new RoyalDurianEffect()));
    }
}
