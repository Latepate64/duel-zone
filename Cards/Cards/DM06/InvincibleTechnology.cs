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
        public override void Apply(IGame game)
        {
            var cards = Applier.Deck.Cards;
            var selectedCards = Applier.ChooseAnyNumberOfCards(cards, ToString()).ToArray();
            Applier.ShowCardsToOpponent(selectedCards);
            game.Move(Ability, ZoneType.Deck, ZoneType.Hand, selectedCards);
            Applier.ShuffleOwnDeck();
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
