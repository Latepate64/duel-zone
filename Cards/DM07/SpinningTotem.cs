using Engine;
using Engine.Abilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

public sealed class SpinningTotem : Creature
{
    public SpinningTotem() : base("Spinning Totem", 5, 4000, Race.MysteryTotem, Civilization.Nature)
    {
        AddAbilities(new TapAbility(new SpinningTotemOneShotEffect()));
    }
}
