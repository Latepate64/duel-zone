using Common;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class FromManaZoneToShieldsFaceDownEffect : CardMovingChoiceEffect
    {
        public FromManaZoneToShieldsFaceDownEffect(FromManaZoneToShieldsFaceDownEffect effect) : base(effect)
        {
        }

        public FromManaZoneToShieldsFaceDownEffect() : base(1, 1, true, ZoneType.ManaZone, ZoneType.ShieldZone)
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

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetController(game).ManaZone.Cards;
        }
    }
}