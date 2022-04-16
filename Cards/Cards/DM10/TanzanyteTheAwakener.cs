using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM10
{
    class TanzanyteTheAwakener : Creature
    {
        public TanzanyteTheAwakener() : base("Tanzanyte, the Awakener", 7, 9000, Race.SpiritQuartz, Civilization.Water, Civilization.Darkness)
        {
            AddDoubleBreakerAbility();
            AddTapAbility(new TanzanyteTheAwakenerEffect());
        }
    }

    class TanzanyteTheAwakenerEffect : OneShotEffects.CardSelectionEffect
    {
        public TanzanyteTheAwakenerEffect() : base(1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new TanzanyteTheAwakenerEffect();
        }

        public override string ToString()
        {
            return "Choose a creature in your graveyard. Return all creatures that have that name from your graveyard to your hand.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            var names = cards.Select(x => x.Name).Distinct();
            var creatures = source.GetController(game).Graveyard.Creatures.Where(x => names.Contains(x.Name));
            game.Move(ZoneType.Graveyard, ZoneType.Hand, creatures.ToArray());
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return source.GetController(game).Graveyard.Creatures;
        }
    }
}
