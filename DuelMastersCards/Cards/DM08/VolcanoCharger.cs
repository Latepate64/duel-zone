using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.StaticAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace Cards.Cards.DM08
{
    public class VolcanoCharger : Spell
    {
        public VolcanoCharger() : base("Volcano Charger", 4, Civilization.Fire)
        {
            // Destroy one of your opponent's creatures that has power 2000 or less.
            Abilities.Add(new SpellAbility(new DestroyEffect(new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(2000), 1, 1, true)));
            Abilities.Add(new ChargerAbility());
        }
    }
}
