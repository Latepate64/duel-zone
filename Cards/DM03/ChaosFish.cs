using ContinuousEffects;
using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM03;

public sealed class ChaosFish : Creature
{
    public ChaosFish() : base("Chaos Fish", 7, 1000, Race.GelFish, Civilization.Water)
    {
        AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Civilization.Water));
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new ChaosFishEffect()));
    }
}
