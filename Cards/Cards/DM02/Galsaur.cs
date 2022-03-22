using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM02
{
    class Galsaur : Creature
    {
        public Galsaur() : base("Galsaur", 5, 4000, Subtype.RockBeast, Civilization.Fire)
        {
            var condition = new Conditions.FilterNoneCondition(new CardFilters.OwnersOtherBattleZoneCreatureFilter());
            AddAbilities(new PowerAttackerAbility(4000, condition), new DoubleBreakerAbility(condition));
        }
    }
}
