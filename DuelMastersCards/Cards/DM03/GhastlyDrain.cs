using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace Cards.Cards.DM03
{
    class GhastlyDrain : Spell
    {
        public GhastlyDrain() : base("Ghastly Drain", 3, Civilization.Darkness)
        {
            // Choose any number of your shields and put them into your hand. You can't use the "shield trigger" abilities of those shields.
            Abilities.Add(new SpellAbility(new OneShotEffects.ShieldRecoveryEffect(new CardFilters.OwnersShieldZoneCardFilter(), 0, int.MaxValue, true, false)));
        }
    }
}
