using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    abstract class SearchEffect : SearchAnyDeckEffect
    {
        public bool Reveal { get; }

        protected SearchEffect(CardFilter filter, bool reveal, int maximum = 1) : base(filter, maximum)
        {
            Reveal = reveal;
        }

        protected SearchEffect(SearchEffect effect) : base(effect)
        {
            Reveal = effect.Reveal;
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            if (Reveal)
            {
                game.GetPlayer(source.Controller).Reveal(game, cards);
            }
            game.Move(Common.ZoneType.Deck, Common.ZoneType.Hand, cards);
            if (Reveal)
            {
                game.GetPlayer(source.Controller)?.Unreveal(cards);
            }
        }
    }

    class SearchSpellEffect : SearchEffect
    {
        public SearchSpellEffect() : base(new CardFilters.OwnersDeckSpellFilter(), true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new SearchSpellEffect();
        }

        public override string ToString()
        {
            return "Search your deck. You may take a spell from your deck, show that spell to your opponent, and put it into your hand. Then shuffle your deck.";
        }
    }

    class SearchCardNoRevealEffect : SearchEffect
    {
        public SearchCardNoRevealEffect() : base(new CardFilters.OwnersDeckCardFilter(), false)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new SearchCardNoRevealEffect();
        }

        public override string ToString()
        {
            return "Search your deck. You may take a card from your deck and put it into your hand. Then shuffle your deck.";
        }
    }

    class SearchCreatureEffect : SearchEffect
    {
        public SearchCreatureEffect() : base(new CardFilters.OwnersDeckCreatureFilter(), true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new SearchCreatureEffect();
        }

        public override string ToString()
        {
            return "Search your deck. You may take a creature from your deck, show that creature to your opponent, and put it into your hand. Then shuffle your deck.";
        }
    }

    class SearchSubtypeCreatureEffect : SearchEffect
    {
        private readonly Common.Subtype _subtype;

        public SearchSubtypeCreatureEffect(Common.Subtype subtype) : base(new CardFilters.OwnersDeckSubtypeCreatureFilter(subtype), true)
        {
            _subtype = subtype;
        }

        public SearchSubtypeCreatureEffect(SearchSubtypeCreatureEffect effect) : base(effect)
        {
            _subtype = effect._subtype;
        }

        public override IOneShotEffect Copy()
        {
            return new SearchSubtypeCreatureEffect(this);
        }

        public override string ToString()
        {
            return $"When you put this creature into the battle zone, search your deck. You may take a {_subtype} from your deck, show that {_subtype} to your opponent, and put it into your hand. Then shuffle your deck.";
        }
    }
}
