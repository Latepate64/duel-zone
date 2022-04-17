using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM06
{
    class MysticTreasureChest : Spell
    {
        public MysticTreasureChest() : base("Mystic Treasure Chest", 3, Civilization.Nature)
        {
            AddSpellAbilities(new MysticTreasureChestEffect());
        }
    }

    class MysticTreasureChestEffect : SearchAnyDeckEffect
    {
        public MysticTreasureChestEffect()
        {
        }

        public MysticTreasureChestEffect(MysticTreasureChestEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new MysticTreasureChestEffect(this);
        }

        public override string ToString()
        {
            return "Search your deck. You may take a non-nature card from your deck and put it into your mana zone. Then shuffle your deck.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.Move(source, ZoneType.Deck, ZoneType.ManaZone, cards);
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return source.GetController(game).Deck.Cards.Where(x => !x.HasCivilization(Civilization.Nature));
        }
    }
}
