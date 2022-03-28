using Common;
using Engine.Abilities;

namespace Cards.Cards.DM03
{
    class KingPonitas : Creature
    {
        public KingPonitas() : base("King Ponitas", 8, 4000, Subtype.Leviathan, Civilization.Water)
        {
            AddWheneverThisCreatureAttacksAbility(new KingPonitasEffect());
        }
    }

    class KingPonitasEffect : OneShotEffects.SearchEffect
    {
        public KingPonitasEffect() : base(new CardFilters.OwnersDeckCivilizationCardFilter(Civilization.Water), true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new KingPonitasEffect();
        }

        public override string ToString()
        {
            return "Search your deck. You may take a water card from your deck, show that card to your opponent, and put it into your hand. Then shuffle your deck.";
        }
    }
}
