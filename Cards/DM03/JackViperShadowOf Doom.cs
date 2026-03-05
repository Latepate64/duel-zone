using ContinuousEffects;
using Interfaces;

namespace Cards.DM03;

public sealed class JackViperShadowOfDoom : EvolutionCreature
{
    public JackViperShadowOfDoom() : base("Jack Viper, Shadow of Doom", 3, 4000, Race.Ghost, Civilization.Darkness)
    {
        AddStaticAbilities(new JackViperShadowOfDoomEffect());
    }
}
