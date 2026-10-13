using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

sealed class ManaNexus : Spell
{
    public ManaNexus() : base("Mana Nexus", 4, Civilization.Nature)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1, 
                maximum: 1,
                controllerChooses: true,
                filter: new AnyCardFilter(),
                source: ZoneType.ManaZone,
                destination: ZoneType.ShieldZone,
                selectionRange: SelectionRange.OwnCreatures
            ));
    }
}