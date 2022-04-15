using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM12
{
    class CosmicDarts : Spell
    {
        public CosmicDarts() : base("Cosmic Darts", 1, Civilization.Light)
        {
            AddSpellAbilities(new CosmicDartsEffect());
        }
    }

    class CosmicDartsEffect : OneShotEffects.CardSelectionEffect
    {
        public CosmicDartsEffect() : base(1, 1, false)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new CosmicDartsEffect();
        }

        public override string ToString()
        {
            return "Your opponent chooses one of your shields. Look at it. If it's a spell, you may cast immediately for no cost. If it's not a spell or if you don't cast it, put it back where it was.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            if (cards.Length == 1)
            {
                source.GetController(game).Look(source.GetController(game), game, cards);
                var card = cards.Single();
                if (card.CardType == CardType.Spell && source.GetController(game).ChooseToTakeAction($"You may cast {card.Name} for no cost."))
                {
                    source.GetController(game).Cast(card, game);
                }
                source.GetController(game).Unreveal(cards);
            }
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetController(game).ShieldZone.Cards;
        }
    }
}
