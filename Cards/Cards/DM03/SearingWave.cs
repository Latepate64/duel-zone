using Cards.OneShotEffects;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class SearingWave : Spell
    {
        public SearingWave() : base("Searing Wave", 5, Civilization.Fire)
        {
            // Destroy all your opponent's creatures that have power 3000 or less.
            AddAbilities(new SpellAbility(new DestroyAreaOfEffect(new CardFilters.OpponentsBattleZoneMaxPowerCreatureFilter(3000))));

            // Choose one of your shields and put it into your graveyard.
            AddAbilities(new SpellAbility(new SelfShieldBurnEffect()));
        }
    }
}
