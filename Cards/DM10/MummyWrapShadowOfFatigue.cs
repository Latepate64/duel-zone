using Engine.Abilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class MummyWrapShadowOfFatigue : Creature
{
    public MummyWrapShadowOfFatigue() : base(
        "Mummy Wrap, Shadow of Fatigue", 3, 1000, Race.Ghost, Civilization.Darkness)
    {
        AddAbilities(new TapAbility(new MummyWrapShadowOfFatigueEffect()));
    }
}
