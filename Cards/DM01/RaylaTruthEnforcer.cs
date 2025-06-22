using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM01
{
    sealed class RaylaTruthEnforcer : Engine.Creature
    {
        public RaylaTruthEnforcer() : base("Rayla, Truth Enforcer", 6, 3000, Interfaces.Race.Berserker, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SearchSpellEffect()));
        }
    }
}
