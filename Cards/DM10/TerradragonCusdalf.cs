using Abilities.Static;
using ContinuousEffects;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM10;

public sealed class TerradragonCusdalf : Creature
{
    public TerradragonCusdalf() : base("Terradragon Cusdalf", 5, 7000, Race.EarthDragon, Civilization.Nature)
    {
        AddStaticAbilities(new PowerAttackerEffect(4000));
        AddAbilities(new DoubleBreakerAbility());
        AddStaticAbilities(new TerradragonCusdalfEffect());
    }
}
