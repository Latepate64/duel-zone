using DuelMastersModels;
using DuelMastersModels.Zones;

namespace DuelMastersCards.OneShotEffects
{
    class DestroyEffect : CardMovingChoiceEffect
    {
        public DestroyEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.BattleZone, ZoneType.Graveyard)
        {
        }
    }
}
