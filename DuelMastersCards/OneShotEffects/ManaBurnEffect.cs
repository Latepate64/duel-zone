using DuelMastersModels;
using DuelMastersModels.Zones;

namespace Cards.OneShotEffects
{
    class ManaBurnEffect : CardMovingChoiceEffect
    {
        public ManaBurnEffect(CardFilter filter, int minimum, int maximum, bool controllerChooses) : base(filter, minimum, maximum, controllerChooses, ZoneType.ManaZone, ZoneType.Graveyard)
        {
        }
    }
}
