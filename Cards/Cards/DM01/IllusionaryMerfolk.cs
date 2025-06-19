using Abilities.Triggered;
using Cards.OneShotEffects;
using Engine;

namespace Cards.Cards.DM01;

public class IllusionaryMerfolk : Creature
{
    public IllusionaryMerfolk() : base("Illusionary Merfolk", 5, 4000, Race.GelFish, Civilization.Water)
    {
        AddTriggeredAbility(new IllusionaryMerfolkAbility(new YouMayDrawUpToThreeCardsEffect()));
    }
}
