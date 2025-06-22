using TriggeredAbilities;
using OneShotEffects;
using Engine;
using Interfaces;

namespace Cards.DM01;

public sealed class IllusionaryMerfolk : Creature
{
    public IllusionaryMerfolk() : base("Illusionary Merfolk", 5, 4000, Race.GelFish, Civilization.Water)
    {
        AddTriggeredAbility(new IllusionaryMerfolkAbility(new YouMayDrawUpToThreeCardsEffect()));
    }
}
