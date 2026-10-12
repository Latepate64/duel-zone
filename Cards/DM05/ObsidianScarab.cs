using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using ContinuousEffects.PowerModifying;
using Abilities.Static;
using CardFilters;

namespace Cards.DM05;

public sealed class ObsidianScarab : Creature
{
    const string ObsidianScarabName = "Obsidian Scarab";

    public ObsidianScarab() : base(ObsidianScarabName, 6, 5000, Race.GiantInsect, Civilization.Nature)
    {
        AddStaticAbilities(new PowerAttackerEffect(3000));
        AddAbilities(new DoubleBreakerAbility());
        AddTriggeredAbility(
            new WhenThisCreatureIsDestroyedAbility(
                new PutCardFromYourManaZoneIntoBattleZoneEffect(
                    minimum: 0,
                    filter: new NameFilter(ObsidianScarabName)
        )));
    }
}
