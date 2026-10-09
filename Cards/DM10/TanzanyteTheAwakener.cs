using Abilities;
using Abilities.Static;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class TanzanyteTheAwakener : Creature
{
    public TanzanyteTheAwakener() : base(
        "Tanzanyte, the Awakener", 7, 9000, Race.SpiritQuartz, Civilization.Water, Civilization.Darkness)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddAbilities(new TapAbility(new TanzanyteTheAwakenerEffect()));
    }
}
