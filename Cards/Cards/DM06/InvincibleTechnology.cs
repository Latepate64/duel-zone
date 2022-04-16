using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM06
{
    class InvincibleTechnology : Spell
    {
        public InvincibleTechnology() : base("Invincible Technology", 13, Civilization.Water)
        {
            AddSpellAbilities(new InvincibleTechnologyEffect());
        }
    }

    class InvincibleTechnologyEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var cards = source.GetController(game).Deck.Cards;
            var selectedCards = source.GetController(game).ChooseAnyNumberOfCards(cards, ToString()).ToArray();
            source.GetController(game).Reveal(game, selectedCards);
            game.Move(ZoneType.Deck, ZoneType.Hand, selectedCards);
            source.GetController(game).ShuffleDeck(game);
            return selectedCards;
        }

        public override IOneShotEffect Copy()
        {
            return new InvincibleTechnologyEffect();
        }

        public override string ToString()
        {
            return "Search your deck. You may take any number of cards from your deck, show those cards to your opponent, and put them into your hand. Then shuffle your deck.";
        }
    }
}
