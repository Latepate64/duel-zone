using ContinuousEffects;
using Interfaces;

namespace Cards.DM02;

public class ArmoredBlasterValdios : EvolutionCreature
{
    public ArmoredBlasterValdios() : base("Armored Blaster Valdios", 4, 6000, Race.Human, Civilization.Fire)
    {
        AddStaticAbilities(new ArmoredBlasterValdiosEffect());
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
