using Common;
using Engine;

namespace Cards.CardFilters
{
    class NonCivilizationSpellFilter : CardFilter
    {
        public NonCivilizationSpellFilter(Civilization civilization)
        {
            Civilization = civilization;
        }

        public NonCivilizationSpellFilter(NonCivilizationSpellFilter filter)
        {
            Civilization = filter.Civilization;
        }

        public Civilization Civilization { get; }

        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return card.CardType == CardType.Spell && !card.HasCivilization(Civilization);
        }

        public override ICardFilter Copy()
        {
            return new NonCivilizationSpellFilter(this);
        }

        public override string ToString()
        {
            return $"non-{Civilization} spell";
        }
    }
}
