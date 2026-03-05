using ContinuousEffects;
using Interfaces;

namespace Cards.DM03;

public sealed class ÜberdragonJabaha : EvolutionCreature
{
    public ÜberdragonJabaha() : base("Überdragon Jabaha", 7, 11000, Race.ArmoredDragon, Civilization.Fire)
    {
        AddStaticAbilities(new ÜberdragonJabahaEffect());
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}
