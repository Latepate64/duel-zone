using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class FloodValve : Spell
    {
        public FloodValve() : base("Flood Valve", 2, Civilization.Water)
        {
            ShieldTrigger = true;

            // Return a card from your mana zone to your hand.
            Abilities.Add(new SpellAbility(new OneShotEffects.ManaRecoveryEffect(new CardFilters.OwnersManaZoneCardFilter(), 1, 1, true)));
        }
    }
}
