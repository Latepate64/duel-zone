using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class InvincibleAbyss : Spell
{
    public InvincibleAbyss() : base("Invincible Abyss", 13, Civilization.Darkness)
    {
        AddSpellAbilities(new InvincibleAbyssEffect());
    }
}
