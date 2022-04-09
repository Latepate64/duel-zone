using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM11
{
    class MiraculousPlague : Spell
    {
        public MiraculousPlague() : base("Miraculous Plague", 7, Civilization.Water, Civilization.Darkness)
        {
            AddSpellAbilities(new MiraculousPlagueFirstEffect());
        }
    }

    class MiraculousPlagueFirstEffect : CardSelectionEffect
    {
        public MiraculousPlagueFirstEffect() : base(new CardFilters.OpponentsBattleZoneChoosableCreatureFilter(), 2, 2, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new MiraculousPlagueFirstEffect();
        }

        public override string ToString()
        {
            return "Choose 2 of your opponent's creatures in the battle zone. Your opponent chooses one of them, puts it into his hand, and destroys the other one. Then choose 2 cards in your opponent's mana zone. Your opponent chooses one of them, puts it into his hand, and puts the other one into his graveyard.";
        }

        protected override void Apply(IGame game, IAbility source, params Engine.ICard[] cards)
        {
            new MiraculousPlagueSecondEffect().Apply(game, source);
            new MiraculousPlagueThirdEffect().Apply(game, source);
        }

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, source.GetOpponent(game).Id);
        }
    }

    class MiraculousPlagueSecondEffect : CardSelectionEffect
    {
        private readonly Engine.ICard[] _cards;

        public MiraculousPlagueSecondEffect(params Engine.ICard[] cards) : base(new CardFilters.TargetsFilter(cards), 1, 1, false)
        {
            _cards = cards;
        }

        public MiraculousPlagueSecondEffect(MiraculousPlagueSecondEffect effect) : base(effect)
        {
            _cards = effect._cards;
        }

        public override IOneShotEffect Copy()
        {
            return new MiraculousPlagueSecondEffect();
        }

        public override string ToString()
        {
            return "Choose a card and put it into your hand, and destroy the other one.";
        }

        protected override void Apply(IGame game, IAbility source, params Engine.ICard[] cards)
        {
            var otherCards = GetSelectableCards(game, source).Except(cards);
            game.Move(ZoneType.BattleZone, ZoneType.Hand, cards);
            game.Destroy(otherCards);
        }

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return _cards;
        }
    }

    class MiraculousPlagueThirdEffect : CardSelectionEffect
    {
        public MiraculousPlagueThirdEffect() : base(new CardFilters.OpponentsManaZoneCardFilter(), 2, 2, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new MiraculousPlagueThirdEffect();
        }

        public override string ToString()
        {
            return "Choose 2 cards in your opponent's mana zone. Your opponent chooses one of them, puts it into his hand, and puts the other one into his graveyard.";
        }

        protected override void Apply(IGame game, IAbility source, params Engine.ICard[] cards)
        {
            new MiraculousPlagueFourthEffect().Apply(game, source);
        }

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetOpponent(game).ManaZone.Cards;
        }
    }

    class MiraculousPlagueFourthEffect : CardSelectionEffect
    {
        private readonly Engine.ICard[] _cards;

        public MiraculousPlagueFourthEffect(params Engine.ICard[] cards) : base(new CardFilters.TargetsFilter(cards), 1, 1, false)
        {
            _cards = cards;
        }

        public MiraculousPlagueFourthEffect(MiraculousPlagueFourthEffect effect) : base(effect)
        {
            _cards = effect._cards;
        }

        public override IOneShotEffect Copy()
        {
            return new MiraculousPlagueFourthEffect();
        }

        public override string ToString()
        {
            return "Choose a card and put it into your hand, and put the other one into your graveyard.";
        }

        protected override void Apply(IGame game, IAbility source, params Engine.ICard[] cards)
        {
            var otherCards = GetSelectableCards(game, source).Except(cards).ToArray();
            game.Move(ZoneType.ManaZone, ZoneType.Hand, cards);
            game.Move(ZoneType.ManaZone, ZoneType.Graveyard, otherCards);
        }

        protected override IEnumerable<Engine.ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return _cards;
        }
    }
}
