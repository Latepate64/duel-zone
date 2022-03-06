using Common;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class BoomerangComet : Spell
    {
        public BoomerangComet() : base("Boomerang Comet", 6, Civilization.Light)
        {
            ShieldTrigger = true;
            AddAbilities(new SpellAbility(new OneShotEffects.ManaRecoveryEffect(new CardFilters.OwnersManaZoneCardFilter(), 1, 1, true)), new StaticAbilities.ChargerAbility());
        }
    }
}
