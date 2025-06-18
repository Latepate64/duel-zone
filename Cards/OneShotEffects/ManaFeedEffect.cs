using Engine;

namespace Cards.OneShotEffects
{
    /// <summary>
    /// Mana Feed is a slang term given to the abilities that put creatures or other cards in the battle zone into its owner's mana zone.
    /// </summary>
    abstract class ManaFeedEffect : CardMovingChoiceEffect<Engine.Creature>
    {
        protected ManaFeedEffect(CardMovingChoiceEffect<Engine.Creature> effect) : base(effect)
        {
        }

        protected ManaFeedEffect(int minimum, int maximum, bool controllerChooses) : base(minimum, maximum, controllerChooses, ZoneType.BattleZone, ZoneType.ManaZone)
        {
        }
    }
}
