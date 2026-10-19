using OneShotEffects;
using Interfaces;
using CardFilters;
using StaticAbilities;
using ContinuousEffects.AbilityAdding;

namespace Cards.DM03;

public sealed class SnakeAttack : Spell
{
    public SnakeAttack(
        EachOfYourCreaturesGetsAbilityEffectFactory oneShotEffectFactory,
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory,
        CreatureFilterFactory creatureFilterFactory,
        CreaturesGetAbilitiesEffectFactory continuousEffectFactory)
        : base("Snake Attack", 4, Civilization.Darkness)
    {
        AddSpellAbilities(
            oneShotEffectFactory.Create(
                creatureFilterFactory.Create(),
                continuousEffectFactory,
                new UntilEndOfThisTurnDuration(),
                doubleBreakerAbilityFactory.Create()
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