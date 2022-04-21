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
        public override void Apply(IGame game, IAbility source)
        {
            var cards = GetController(game).Deck.Cards;
            var selectedCards = GetController(game).ChooseAnyNumberOfCards(cards, ToString()).ToArray();
            GetController(game).Reveal(game, selectedCards);
            game.Move(source, ZoneType.Deck, ZoneType.Hand, selectedCards);
            GetController(game).ShuffleDeck(game);
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
