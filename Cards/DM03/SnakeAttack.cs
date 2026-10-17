using OneShotEffects;
using Interfaces;
using CardFilters;
using Abilities.Static;
using ContinuousEffects.AbilityAdding;

namespace Cards.DM03;

public sealed class SnakeAttack : Spell
{
    public SnakeAttack(
        EachOfYourCreaturesGetsAbilityUntilEndOfTurnEffectFactory oneShotEffectFactory,
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory,
        CreatureFilterFactory creatureFilterFactory,
        ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffectFactory continuousEffectFactory)
        : base("Snake Attack", 4, Civilization.Darkness)
    {
        AddSpellAbilities(
            oneShotEffectFactory.Create(
                doubleBreakerAbilityFactory.Create(),
                creatureFilterFactory.Create(),
                continuousEffectFactory
            ),
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new AnyCardFilter(),
                source: ZoneType.ShieldZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OwnCards
        ));
    }
}