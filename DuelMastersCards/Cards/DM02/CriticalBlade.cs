using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace Cards.Cards.DM02
{
    class CriticalBlade : Spell
    {
        public CriticalBlade() : base("Critical Blade", 2, Civilization.Darkness)
        {
            ShieldTrigger = true;

            // Destroy one of your opponent's creatures that has "blocker."
            Abilities.Add(new SpellAbility(new OneShotEffects.DestroyEffect(new CardFilters.OpponentsBattleZoneChoosableBlockerCreatureFilter(), 1, 1, true)));
        }
    }
}
