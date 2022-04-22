using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    abstract class SearchEffect : SearchAnyDeckEffect
    {
        public bool Reveal { get; }

        protected SearchEffect(bool reveal, int maximum = 1) : base(maximum)
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
                Controller.Reveal(game, cards);
            }
            game.Move(Ability, ZoneType.Deck, ZoneType.Hand, cards);
            if (Reveal)
            {
                Controller?.Unreveal(cards);
            }
        }
    }

    class SearchSpellEffect : SearchEffect
    {
        public SearchSpellEffect() : base(true)
        {
        }

        public SearchSpellEffect(SearchEffect effect) : base(effect)
        {
        }

        public SearchSpellEffect(bool reveal, int maximum = 1) : base(reveal, maximum)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new SearchSpellEffect(this);
        }

        public override string ToString()
        {
            return "Search your deck. You may take a spell from your deck, show that spell to your opponent, and put it into your hand. Then shuffle your deck.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return Controller.Deck.Spells;
        }
    }

    class SearchCardNoRevealEffect : SearchEffect
    {
        public SearchCardNoRevealEffect() : base(false)
        {
        }

        public SearchCardNoRevealEffect(SearchEffect effect) : base(effect)
        {
        }

        public SearchCardNoRevealEffect(bool reveal, int maximum = 1) : base(reveal, maximum)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new SearchCardNoRevealEffect(this);
        }

        public override string ToString()
        {
            return "Search your deck. You may take a card from your deck and put it into your hand. Then shuffle your deck.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return Controller.Deck.Cards;
        }
    }

    class SearchCreatureEffect : SearchEffect
    {
        public SearchCreatureEffect() : base(true)
        {
        }

        public SearchCreatureEffect(SearchEffect effect) : base(effect)
        {
        }

        public SearchCreatureEffect(bool reveal, int maximum = 1) : base(reveal, maximum)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new SearchCreatureEffect(this);
        }

        public override string ToString()
        {
            return "Search your deck. You may take a creature from your deck, show that creature to your opponent, and put it into your hand. Then shuffle your deck.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return Controller.Deck.Creatures;
        }
    }

    class SearchRaceCreatureEffect : SearchEffect
    {
        private readonly Race _race;

        public SearchRaceCreatureEffect(Race race) : base(true)
        {
            _race = race;
        }

        public SearchRaceCreatureEffect(SearchRaceCreatureEffect effect) : base(effect)
        {
            _race = effect._race;
        }

        public override IOneShotEffect Copy()
        {
            return new SearchRaceCreatureEffect(this);
        }

        public override string ToString()
        {
            return $"When you put this creature into the battle zone, search your deck. You may take a {_race} from your deck, show that {_race} to your opponent, and put it into your hand. Then shuffle your deck.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return Controller.Deck.GetCreatures(_race);
        }
    }

    class SearchCardWithNameEffect : SearchEffect
    {
        private readonly string _name;

        public SearchCardWithNameEffect(SearchCardWithNameEffect effect) : base(effect)
        {
            _name = effect._name;
        }

        public SearchCardWithNameEffect(string name) : base(true)
        {
            _name = name;
        }

        public override IOneShotEffect Copy()
        {
            return new SearchCardWithNameEffect(this);
        }

        public override string ToString()
        {
            return $"Search your deck. You may take a {_name} from your deck, show that card to your opponent, and put it into your hand. Then shuffle your deck.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return Controller.Deck.Cards.Where(x => x.Name == _name);
        }
    }
}
