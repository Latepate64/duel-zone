using ContinuousEffects;
using Interfaces;

namespace Cards.Promo;

public sealed class ArmoredGroblav : EvolutionCreature
{
    public ArmoredGroblav() : base("Armored Groblav", 5, 6000, Race.Human, Civilization.Fire)
    {
        AddStaticAbilities(new ArmoredGroblavEffect());
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
