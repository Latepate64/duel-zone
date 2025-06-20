using Abilities.Triggered;
using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class RaylaTruthEnforcer : Engine.Creature
    {
        public RaylaTruthEnforcer() : base("Rayla, Truth Enforcer", 6, 3000, Engine.Race.Berserker, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SearchSpellEffect()));
        }
    }
}
