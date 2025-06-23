using TriggeredAbilities;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class DolmarksTheShadowWarrior : Creature
{
    public DolmarksTheShadowWarrior() : base(
        "Dolmarks, the Shadow Warrior", 4, 4000, [Race.Ghost, Race.Human], Civilization.Darkness, Civilization.Fire)
    {
        AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DolmarksTheShadowWarriorEffect()));
    }
}
