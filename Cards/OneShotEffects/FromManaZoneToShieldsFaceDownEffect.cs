using Common;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class FromManaZoneToShieldsFaceDownEffect : CardMovingChoiceEffect
    {
        public FromManaZoneToShieldsFaceDownEffect(FromManaZoneToShieldsFaceDownEffect effect) : base(effect)
        {
        }

        public FromManaZoneToShieldsFaceDownEffect() : base(new CardFilters.OwnersManaZoneCardFilter(), 1, 1, true, ZoneType.ManaZone, ZoneType.ShieldZone)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new FromManaZoneToShieldsFaceDownEffect(this);
        }

        public override string ToString()
        {
            return "Add a card from your mana zone to your shields face down.";
        }
    }
}