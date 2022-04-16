using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class RaylaTruthEnforcer : Creature
    {
        public RaylaTruthEnforcer() : base("Rayla, Truth Enforcer", 6, 3000, Engine.Race.Berserker, Engine.Civilization.Light)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new SearchSpellEffect());
        }
    }
}
