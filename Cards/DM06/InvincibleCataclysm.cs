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
            new ShieldBurnEffect(
                minimum: 0,
                maximum: 3,
                filter: new AnyCardFilter(),
                ownShields: false
        ));
    }
}
