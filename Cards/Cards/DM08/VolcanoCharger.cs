using Cards.CardFilters;
using Cards.OneShotEffects;

namespace Cards.Cards.DM08
{
    class VolcanoCharger : Charger
    {
        public VolcanoCharger() : base("Volcano Charger", 4, Common.Civilization.Fire)
        {
            // Destroy one of your opponent's creatures that has power 2000 or less.
            AddSpellAbilities(new DestroyEffect(new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(2000), 1, 1, true));
        }
    }
}
