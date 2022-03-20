using Cards.OneShotEffects;
using Common;

namespace Cards.Cards.DM03
{
    class SearingWave : Spell
    {
        public SearingWave() : base("Searing Wave", 5, Civilization.Fire)
        {
            // Destroy all your opponent's creatures that have power 3000 or less.
            // Choose one of your shields and put it into your graveyard.
            AddSpellAbilities(new DestroyAreaOfEffect(new CardFilters.OpponentsBattleZoneMaxPowerCreatureFilter(3000)), new SelfShieldBurnEffect());
        }
    }
}
