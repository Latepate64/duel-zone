using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class LogicSphere : Spell
    {
        public LogicSphere() : base("Logic Sphere", 3, Civilization.Light)
        {
            ShieldTrigger = true;

            // Return a spell from your mana zone to your hand.
            Abilities.Add(new SpellAbility(new OneShotEffects.ManaRecoveryEffect(new CardFilters.OwnersManaZoneCardFilter { CardType = CardType.Spell }, 1, 1, true)));
        }
    }
}
