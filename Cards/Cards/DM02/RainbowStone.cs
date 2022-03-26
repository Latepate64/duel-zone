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
            AddSpellAbilities(new RainbowStoneEffect());
        }
    }

    class RainbowStoneEffect : SearchAnyDeckEffect
    {
        public RainbowStoneEffect() : base(new CardFilters.OwnersDeckCardFilter())
        {
        }

        public RainbowStoneEffect(SearchAnyDeckEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new RainbowStoneEffect(this);
        }

        public override string ToString()
        {
            return "Search your deck. You may take a card from your deck and put it into your mana zone. Then shuffle your deck.";
        }

        protected override void Apply(IGame game, IAbility source, params Engine.ICard[] cards)
        {
            game.Move(ZoneType.Deck, ZoneType.ManaZone, cards);
        }
    }
}
