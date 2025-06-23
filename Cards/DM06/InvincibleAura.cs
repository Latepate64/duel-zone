using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class InvincibleAura : Spell
{
    public InvincibleAura() : base("Invincible Aura", 13, Civilization.Light)
    {
        AddSpellAbilities(new InvincibleAuraEffect());
    }
}
