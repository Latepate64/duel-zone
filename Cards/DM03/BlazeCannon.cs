using ContinuousEffects;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

public sealed class BlazeCannon : Spell
{
    public BlazeCannon() : base("Blaze Cannon", 7, Civilization.Fire)
    {
        AddStaticAbilities(new BlazeCannonRestrictionEffect());
        AddSpellAbilities(new BlazeCannonBuffEffect());
    }
}
