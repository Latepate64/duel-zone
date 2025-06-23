using TriggeredAbilities;
using ContinuousEffects;
using OneShotEffects;
using Interfaces;

namespace Cards.DM05;

public sealed class ObsidianScarab : Creature
{
    const string ObsidianScarabName = "Obsidian Scarab";

    public ObsidianScarab() : base(ObsidianScarabName, 6, 5000, Race.GiantInsect, Civilization.Nature)
    {
        AddStaticAbilities(new PowerAttackerEffect(3000));
        AddStaticAbilities(new DoubleBreakerEffect());
        AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(
            new YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect(ObsidianScarabName)));
    }
}
