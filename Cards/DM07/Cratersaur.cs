using Abilities.Static;
using ContinuousEffects;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM07;

internal sealed class Cratersaur : Creature
{
    internal Cratersaur(
        StaticAbilityFactory abilityFactory,
        PowerAttackerEffectFactory effectFactory)
        : base("Cratersaur", 3, 2000, Race.RockBeast, Civilization.Fire)
    {
        AddStaticAbilities(
            new CratersaurEffect(
                3000,
                abilityFactory,
                effectFactory));
    }
}
