using DuelMastersModels;
using DuelMastersModels.Zones;

namespace DuelMastersCards.OneShotEffects
{
    class ManaFeedEffect : CardMovingChoiceEffect
    {
        /// <summary>
        /// Mana Feed is a slang term given to the abilities that put creatures or other cards in the battle zone into its owner's mana zone.
        /// </summary>
        public ManaFeedEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.BattleZone, ZoneType.ManaZone)
        {
        }
    }
}
