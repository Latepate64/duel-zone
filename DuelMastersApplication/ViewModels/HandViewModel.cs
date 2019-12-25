using DuelMastersModels.Cards;
using DuelMastersModels.Zones;
using System.Linq;

namespace DuelMastersApplication.ViewModels
{
    public class HandViewModel : ZoneViewModel
    {
        public override void Update(Zone zone)
        {
            UpdateCards(zone);
        }
    }
}
