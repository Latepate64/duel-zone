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
            new ChooseAndDestroyOpponentsCreaturesEffect(
                1, 1, new MultiFilter(
                    new BlockerFilter(),
                    new MaxPowerFilter(6000)
                )
            ));
    }
}
