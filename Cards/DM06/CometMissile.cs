using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class CometMissile : Spell
{
    public CometMissile() : base("Comet Missile", 1, Civilization.Fire)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new MultiFilter(
                    new BlockerFilter(),
                    new MaxPowerFilter(6000)
                ),
                source: ZoneType.BattleZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OpponentsCards
            ));
    }
}
