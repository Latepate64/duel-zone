using Engine;
using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Mana Feed is a slang term given to the abilities that put creatures or other cards in the battle zone into its
/// owner's mana zone.
/// </summary>
public abstract class ManaFeedEffect : CardMovingChoiceEffect<Creature>
{
    protected ManaFeedEffect(CardMovingChoiceEffect<Creature> effect) : base(effect)
    {
    }

    protected ManaFeedEffect(int minimum, int maximum, bool controllerChooses) : base(
        minimum, maximum, controllerChooses, ZoneType.BattleZone, ZoneType.ManaZone)
    {
    }
}
