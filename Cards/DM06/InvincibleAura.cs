using Engine;
using Interfaces;

namespace Cards.DM06;

public class InvincibleAura : Spell
{
    public InvincibleAura() : base("Invincible Aura", 13, Civilization.Light)
    {
        AddSpellAbilities(new InvincibleAuraEffect());
    }
}
