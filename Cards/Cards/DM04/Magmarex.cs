using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM04
{
    class Magmarex : Engine.Creature
    {
        public Magmarex() : base("Magmarex", 5, 3000, Engine.Race.RockBeast, Engine.Civilization.Fire)
        {
            AddShieldTrigger();
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DestroyAllCreaturesThatHaveExactPower(1000)));
        }
    }
}
