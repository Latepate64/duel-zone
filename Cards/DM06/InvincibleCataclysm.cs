using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class InvincibleCataclysm : Spell
{
    public InvincibleCataclysm() : base("Invincible Cataclysm", 13,
        Civilization.Fire)
    {
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 0,
                maximum: 3,
                controllerChooses: true,
                filter: new AnyCardFilter(),
                source: ZoneType.ShieldZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OpponentsCreatures
        ));
    }
}
