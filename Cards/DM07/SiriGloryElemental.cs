using Abilities.Static;
using ContinuousEffects.AbilityAdding;
using Interfaces;

namespace Cards.DM07;

sealed class SiriGloryElemental : Creature
{
    public SiriGloryElemental() : base("Siri, Glory Elemental", 6, 7000, Race.AngelCommand, Civilization.Light)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddStaticAbilities(new SiriEffect());
    }
}
