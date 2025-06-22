using Engine;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM10;

public class MummyWrapShadowOfFatigue : Creature
{
    public MummyWrapShadowOfFatigue() : base(
        "Mummy Wrap, Shadow of Fatigue", 3, 1000, Race.Ghost, Civilization.Darkness)
    {
        AddAbilities(new TapAbility(new MummyWrapShadowOfFatigueEffect()));
    }
}
