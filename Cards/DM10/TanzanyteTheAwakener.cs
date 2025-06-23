using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class TanzanyteTheAwakener : Creature
{
    public TanzanyteTheAwakener() : base(
        "Tanzanyte, the Awakener", 7, 9000, Race.SpiritQuartz, Civilization.Water, Civilization.Darkness)
    {
        AddStaticAbilities(new DoubleBreakerEffect());
        AddAbilities(new TapAbility(new TanzanyteTheAwakenerEffect()));
    }
}
