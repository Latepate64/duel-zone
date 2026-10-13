using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

sealed class LogicSphere : Spell
{
    public LogicSphere() : base("Logic Sphere", 3, Civilization.Light)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new SpellFilter(),
                source: ZoneType.ManaZone,
                destination: ZoneType.Hand,
                selectionRange: SelectionRange.OwnCards
        ));
    }
}