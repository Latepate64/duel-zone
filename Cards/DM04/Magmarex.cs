using TriggeredAbilities;
using OneShotEffects;
using Interfaces;
using CardFilters;

namespace Cards.DM04;

sealed class Magmarex : Creature
{
    public Magmarex() : base("Magmarex", 5, 3000, Race.RockBeast,
        Civilization.Fire)
    {
        AddShieldTrigger();
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new DestroyAreaOfEffect(
                    filter: new PowerFilter(1000),
                    selectionRange: SelectionRange.AllCards,
                    excludeSource: false
                )));
    }
}