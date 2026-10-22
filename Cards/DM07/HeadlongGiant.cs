using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using ContinuousEffects.CannotAttack;
using ContinuousEffects.Unblockable;
using StaticAbilities;
using CardFilters;

namespace Cards.DM07;

sealed class HeadlongGiant : Creature
{
    public HeadlongGiant() : base("Headlong Giant", 9, 14000, Race.Giant,
        Civilization.Nature)
    {
        AddStaticAbilities(
            new ThisCreatureCannotAttackEffect(new ControllerHasNoHandCardsCondition()),
            new ThisCreatureCannotBeBlockedEffect(new MaxPowerFilter(4000)));
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new CardMovingChoiceEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new AnyCardFilter(),
                    source: ZoneType.Hand,
                    destination: ZoneType.Graveyard,
                    selectionRange: SelectionRange.OwnCards
        )));
        AddAbilities(new TripleBreakerAbility());
    }
}
