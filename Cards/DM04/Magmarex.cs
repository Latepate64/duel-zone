using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM04
{
    class Magmarex : Engine.Creature
    {
        public Magmarex() : base("Magmarex", 5, 3000, Interfaces.Race.RockBeast, Interfaces.Civilization.Fire)
        {
            AddShieldTrigger();
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DestroyAllCreaturesThatHaveExactPower(1000)));
        }
    }
}
