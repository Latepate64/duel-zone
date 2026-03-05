using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class InvincibleCataclysm : Spell
{
    public InvincibleCataclysm() : base("Invincible Cataclysm", 13, Civilization.Fire)
    {
        AddSpellAbilities(new InvincibleCataclysmEffect());
    }
}
