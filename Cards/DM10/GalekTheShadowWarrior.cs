using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class GalekTheShadowWarrior : Creature
{
    public GalekTheShadowWarrior() : base(
        "Galek, the Shadow Warrior", 5, 2000, [Race.Ghost, Race.Human], Civilization.Darkness, Civilization.Fire)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new GalekTheShadowWarriorEffect()));
    }
}
