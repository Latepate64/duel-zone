using ContinuousEffects;
using Interfaces;

namespace Cards.DM10;

public sealed class BodaciousGiant : Creature
{
    public BodaciousGiant() : base("Bodacious Giant", 8, 12000, Race.Giant, Civilization.Nature)
    {
        AddStaticAbilities(new DoubleBreakerEffect());
        AddStaticAbilities(new BodaciousGiantEffect());
    }
}
