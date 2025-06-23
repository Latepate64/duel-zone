using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class TerradragonDakmaBalgarow : Creature
{
    public TerradragonDakmaBalgarow() : base(
        "Terradragon Dakma Balgarow", 7, 1000, Race.EarthDragon, Civilization.Nature)
    {
        AddStaticAbilities(new TerradragonDakmaBalgarowEffect(), new PoweredTripleBreaker());
    }
}
