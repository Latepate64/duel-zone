using DuelMastersModels;
using DuelMastersModels.Zones;

namespace DuelMastersCards.OneShotEffects
{
    class ManaBurnEffect : CardMovingChoiceEffect
    {
        public ManaBurnEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.ManaZone, ZoneType.Graveyard)
        {
        }
    }
}
