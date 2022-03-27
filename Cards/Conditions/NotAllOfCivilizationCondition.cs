using Common;
using Engine;
using System;

namespace Cards.Conditions
{
    class NotAllOfCivilizationCondition : AllOfCivilizationCondition
    {
        internal NotAllOfCivilizationCondition(Civilization civilization) : base(civilization)
        {
        }

        internal NotAllOfCivilizationCondition(NotAllOfCivilizationCondition condition) : base(condition)
        {
        }

        public override bool Applies(IGame game, Guid player)
        {
            return !base.Applies(game, player);
        }

        public override Condition Copy()
        {
            return new NotAllOfCivilizationCondition(this);
        }

        public override string ToString()
        {
            return $"Not all the cards in {Filter} are {Civilization} cards";
        }
    }
}
