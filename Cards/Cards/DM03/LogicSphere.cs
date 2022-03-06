using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class LogicSphere : Spell
    {
        public LogicSphere() : base("Logic Sphere", 3, Common.Civilization.Light)
        {
            ShieldTrigger = true;

            // Return a spell from your mana zone to your hand.
            AddAbilities(new SpellAbility(new OneShotEffects.ManaRecoveryEffect(new CardFilters.OwnersManaZoneCardFilter { CardType = Common.CardType.Spell }, 1, 1, true)));
        }
    }
}
