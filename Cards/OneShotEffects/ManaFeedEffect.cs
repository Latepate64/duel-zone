using Common;
using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ManaFeedEffect : CardMovingChoiceEffect
    {
        public ManaFeedEffect(CardMovingChoiceEffect effect) : base(effect)
        {
        }

        /// <summary>
        /// Mana Feed is a slang term given to the abilities that put creatures or other cards in the battle zone into its owner's mana zone.
        /// </summary>
        public ManaFeedEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.BattleZone, ZoneType.ManaZone)
        {
        }

        public override OneShotEffect Copy()
        {
            return new ManaFeedEffect(this);
        }

        public override string ToString()
        {
            return $"{(ControllerChooses ? "Put" : "Your opponent puts")} {GetAmountAsText()} {Filter} into its owner's mana zone.";
        }
    }
}
