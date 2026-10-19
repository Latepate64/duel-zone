using Abilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class SkyCrusherTheAgitator : Creature
{
    public SkyCrusherTheAgitator() : base("Sky Crusher, the Agitator", 7, 4000,
        Race.Dragonoid, Civilization.Fire)
    {
        AddAbilities(
            new TapAbility(
                new MutualManaSacrificeEffect(1)));
    }
}