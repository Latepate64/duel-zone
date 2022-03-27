using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class RaylaTruthEnforcer : Creature
    {
        public RaylaTruthEnforcer() : base("Rayla, Truth Enforcer", 6, 3000, Common.Subtype.Berserker, Common.Civilization.Light)
        {
            AddAbilities(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SearchSpellEffect()));
        }
    }
}
