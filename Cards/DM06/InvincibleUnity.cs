using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class InvincibleUnity : Spell
{
    public InvincibleUnity() : base("Invincible Unity", 13, Civilization.Nature)
    {
        AddSpellAbilities(new InvincibleUnityOneShotEffect());
    }
}
