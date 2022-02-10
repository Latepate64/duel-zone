using Common;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    /// <summary>
    /// Choose up to X creatures in the battle zone and return them to their owners' hands.
    /// </summary>
    public class BounceEffect : CardMovingChoiceEffect
    {
        public BounceEffect(int minimum, int maximum, CardFilter cardFilter) : base(cardFilter, minimum, maximum, true, ZoneType.BattleZone, ZoneType.Hand)
        {
        }

        public BounceEffect(CardMovingChoiceEffect effect) : base(effect)
        {
        }

        public override string ToString()
        {
            return $"Choose {GetAmountAsText()} {Filter} in the battle zone and return them to their owners' hands.";
        }

        public override OneShotEffect Copy()
        {
            return new BounceEffect(this);
        }
    }
}
