using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class RainbowStone : Spell
    {
        public RainbowStone() : base("Rainbow Stone", 4, Civilization.Nature)
        {
            AddAbilities(new SpellAbility(new RainbowStoneEffect()));
        }
    }

    class RainbowStoneEffect : SearchDeckEffect
    {
        public RainbowStoneEffect() : base(new CardFilters.OwnersDeckCardFilter())
        {
        }

        public RainbowStoneEffect(SearchDeckEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new RainbowStoneEffect(this);
        }

        public override string ToString()
        {
            return "Search your deck. You may take a card from your deck and put it into your mana zone. Then shuffle your deck.";
        }

        protected override void Apply(Game game, Ability source, params Engine.Card[] cards)
        {
            game.Move(ZoneType.Deck, ZoneType.ManaZone, cards);
        }
    }
}
