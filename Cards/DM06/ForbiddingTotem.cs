using Engine;
using Interfaces;

namespace Cards.DM06;

public sealed class ForbiddingTotem : Creature
{
    public ForbiddingTotem() : base("Forbidding Totem", 5, 4000, Race.MysteryTotem, Civilization.Nature)
    {
        AddStaticAbilities(new ForbiddingTotemAbility());
    }
}
