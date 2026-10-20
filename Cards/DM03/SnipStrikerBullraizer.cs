using CardFilters;
using ContinuousEffects.CannotAttack;
using Interfaces;
using Interfaces.Zones;

namespace Cards.DM03;

public sealed class SnipStrikerBullraizer : Creature
{
    public SnipStrikerBullraizer(IBattleZone battleZone) : base("Snip Striker Bullraizer", 2, 3000, Race.Dragonoid, Civilization.Fire)
    {
        AddStaticAbilities(
            new ThisCreatureCannotAttackEffect(
                new OpponentControlsMoreCreaturesThanControllerCondition(
                    battleZone,
                    new CreatureFilter())));
    }
}
