using OneShotEffects;
using Engine;
using Interfaces;

namespace Cards.DM02;

public sealed class RumbleGate : Spell
{
    public RumbleGate() : base("Rumble Gate", 4, Civilization.Fire)
    {
        AddSpellAbilities(new EachOfYourCreaturesGetsPowerUntilTheEndOfTheTurnEffect(1000),
            new RumbleGateOneShotEffect());
    }
}
