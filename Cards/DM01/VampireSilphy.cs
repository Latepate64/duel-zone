using TriggeredAbilities;
using OneShotEffects;
using CardFilters;
using Interfaces;

namespace Cards.DM01;

sealed class VampireSilphy : Creature
{
    public VampireSilphy() : base("Vampire Silphy", 8, 4000, Race.DarkLord,
        Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new DestroyAllCreaturesEffect(
                    new MaxPowerFilter(3000))));
    }
}