using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.OneShotEffects
{
    abstract class UntapAreaOfEffect : OneShotAreaOfEffect
    {
        protected UntapAreaOfEffect(CardFilter filter) : base(filter)
        {
        }

        protected UntapAreaOfEffect(UntapAreaOfEffect effect) : base(effect)
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            source.GetController(game).Untap(game, GetAffectedCards(game, source).ToArray());
            return true;
        }
    }

    class UntapAllTheCardsInYourManaZoneEffect : UntapAreaOfEffect
    {
        public UntapAllTheCardsInYourManaZoneEffect() : base(new CardFilters.OwnersManaZoneCardFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new UntapAllTheCardsInYourManaZoneEffect();
        }

        public override string ToString()
        {
            return "Untap all the cards in your mana zone.";
        }
    }
}
