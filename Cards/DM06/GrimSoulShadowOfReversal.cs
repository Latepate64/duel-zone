using Engine;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM06;

public sealed class GrimSoulShadowOfReversal : Creature
{
    public GrimSoulShadowOfReversal() : base(
        "Grim Soul, Shadow of Reversal", 5, 3000, Race.Ghost, Civilization.Darkness)
    {
        AddAbilities(new TapAbility(new GrimSoulShadowOfReversalEffect()));
    }
}
