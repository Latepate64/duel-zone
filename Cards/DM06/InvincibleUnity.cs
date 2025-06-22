using Engine;
using Interfaces;

namespace Cards.DM06;

public class InvincibleUnity : Spell
{
    public InvincibleUnity() : base("Invincible Unity", 13, Civilization.Nature)
    {
        AddSpellAbilities(new InvincibleUnityOneShotEffect());
    }
}
