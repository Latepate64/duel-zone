using TriggeredAbilities;
using ContinuousEffects;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.Promo;

public sealed class BrigadeShellQ : Creature
{
    public BrigadeShellQ() : base("Brigade Shell Q", 3, 1000, [Race.Survivor, Race.ColonyBeetle], Civilization.Nature)
    {
        AddStaticAbilities(new SurvivorEffect(new WheneverThisCreatureAttacksAbility(new BrigadeShellQEffect())));
    }
}
