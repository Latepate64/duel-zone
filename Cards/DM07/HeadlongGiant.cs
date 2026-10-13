using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using ContinuousEffects.CannotAttack;
using ContinuousEffects.Unblockable;
using Abilities.Static;
using CardFilters;

namespace Cards.DM07;

sealed class HeadlongGiant : Creature
{
    public HeadlongGiant() : base("Headlong Giant", 9, 14000, Race.Giant,
        Civilization.Nature)
    {
        AddStaticAbilities(
            new HeadlongGiantEffect(),
            new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(
                4000));
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new DiscardEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new AnyCardFilter(),
                    selectionRange: SelectionRange.OwnCreatures
        )));
        AddAbilities(new TripleBreakerAbility());
    }
}
