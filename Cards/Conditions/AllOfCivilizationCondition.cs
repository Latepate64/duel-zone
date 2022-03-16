using Engine;
using System.Linq;

namespace Cards.Conditions
{
    class AllOfCivilizationCondition : Condition
    {
        public Common.Civilization Civilization { get; }

        internal AllOfCivilizationCondition(Common.Civilization civilization) : base(new CardFilters.OwnersManaZoneCardFilter())
        {
            Civilization = civilization;
        }

        internal AllOfCivilizationCondition(AllOfCivilizationCondition condition) : base(condition)
        {
            Civilization = condition.Civilization;
        }

        public override bool Applies(Game game, System.Guid player)
        {
            return game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(player))).All(x => x.Civilizations.Contains(Civilization));
        }

        public override string ToString()
        {
            return $"All the cards in {Filter} are {Civilization} cards";
        }

        public override Condition Copy()
        {
            return new AllOfCivilizationCondition(this);
        }
    }
}
