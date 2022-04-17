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
                source.GetController(game).Reveal(game, cards);
            }
            game.Move(source, ZoneType.Deck, ZoneType.Hand, cards);
            if (Reveal)
            {
                source.GetController(game)?.Unreveal(cards);
            }
        }
    }

    class SearchSpellEffect : SearchEffect
    {
        public SearchSpellEffect() : base(true)
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

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return source.GetController(game).Deck.Spells;
        }
    }

    class SearchCardNoRevealEffect : SearchEffect
    {
        public SearchCardNoRevealEffect() : base(false)
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

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return source.GetController(game).Deck.Cards;
        }
    }

    class SearchCreatureEffect : SearchEffect
    {
        public SearchCreatureEffect() : base(true)
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

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return source.GetController(game).Deck.Creatures;
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
            return source.GetController(game).Deck.GetCreatures(_race);
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
            return source.GetController(game).Deck.Cards.Where(x => x.Name == _name);
        }
    }

    class BrutalChargeSearchEffect : SearchEffect
    {
        private readonly int _amount;

        public BrutalChargeSearchEffect(BrutalChargeSearchEffect effect) : base(effect)
        {
            _amount = effect._amount;
        }

        public BrutalChargeSearchEffect(int amount) : base(true, amount)
        {
            _amount = amount;
        }

        public override IOneShotEffect Copy()
        {
            return new BrutalChargeSearchEffect(this);
        }

        public override string ToString()
        {
            return $"Search your deck. Take up to {_amount} creatures from your deck, show them to your opponent, and put them into your hand. Then shuffle your deck.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return source.GetController(game).Deck.Creatures;
        }
    }
}
