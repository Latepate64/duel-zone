using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM06
{
    class FutureSlash : Spell
    {
        public FutureSlash() : base("Future Slash", 7, Civilization.Darkness)
        {
            AddSpellAbilities(new FutureSlashEffect());
        }
    }

    class FutureSlashEffect : OneShotEffects.SearchAnyDeckEffect
    {
        public FutureSlashEffect() : base(2, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new FutureSlashEffect();
        }

        public override string ToString()
        {
            return "Search your opponent's deck. Take up to 2 cards from his deck and put them into his graveyard. Then your opponent shuffles his deck.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.Move(GetSourceAbility(game), ZoneType.Deck, ZoneType.Graveyard, cards);
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return GetOpponent(game).Deck.Cards;
        }
    }
}
