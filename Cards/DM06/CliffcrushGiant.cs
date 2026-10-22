using StaticAbilities;
using CardFilters;
using ContinuousEffects.CannotAttack;
using Interfaces;
using Interfaces.Zones;

namespace Cards.DM06;

public sealed class CliffcrushGiant : Creature
{
    public CliffcrushGiant(IBattleZone battleZone) : base("Cliffcrush Giant", 5, 7000, Race.Giant,
        Civilization.Nature)
    {
        AddStaticAbilities(
            new ThisCreatureCannotAttackEffect(
                new ControllerControlsAnyOtherCreaturesCondition(
                    battleZone,
                    new UntappedCreatureFilter())));
        AddAbilities(new DoubleBreakerAbility());
    }
}
