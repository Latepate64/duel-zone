using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class CometMissile : Spell
{
    public CometMissile() : base("Comet Missile", 1, Civilization.Fire)
    {
        AddShieldTrigger();
        AddSpellAbilities(new CometMissileEffect());
    }
}
