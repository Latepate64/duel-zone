using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM09;

public sealed class TerradragonAnristVhal : Creature
{
    public TerradragonAnristVhal() : base("Terradragon Anrist Vhal", 6, 0, Race.EarthDragon, Civilization.Nature)
    {
        AddStaticAbilities(new TerradragonAnristVhalEffect(), new PoweredDoubleBreaker());
    }
}
