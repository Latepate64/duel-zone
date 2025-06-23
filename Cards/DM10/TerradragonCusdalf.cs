using ContinuousEffects;
using Interfaces;

namespace Cards.DM10;

public sealed class TerradragonCusdalf : Creature
{
    public TerradragonCusdalf() : base("Terradragon Cusdalf", 5, 7000, Race.EarthDragon, Civilization.Nature)
    {
        AddStaticAbilities(new PowerAttackerEffect(4000));
        AddStaticAbilities(new DoubleBreakerEffect());
        AddStaticAbilities(new TerradragonCusdalfEffect());
    }
}
