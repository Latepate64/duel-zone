using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    abstract class UntapAreaOfEffect : OneShotAreaOfEffect
    {
        protected UntapAreaOfEffect() : base()
        {
        }

        protected UntapAreaOfEffect(UntapAreaOfEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game, IAbility source)
        {
            GetController(game).Untap(game, GetAffectedCards(game, source).ToArray());
        }
    }

    class UntapAllTheCardsInYourManaZoneEffect : UntapAreaOfEffect
    {
        public UntapAllTheCardsInYourManaZoneEffect() : base()
        {
        }

        public UntapAllTheCardsInYourManaZoneEffect(UntapAreaOfEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new UntapAllTheCardsInYourManaZoneEffect(this);
        }

        public override string ToString()
        {
            return "Untap all the cards in your mana zone.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return GetController(game).ManaZone.Cards;
        }
    }
}
