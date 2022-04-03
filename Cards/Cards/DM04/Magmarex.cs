using Cards.OneShotEffects;
using Common;

namespace Cards.Cards.DM04
{
    class Magmarex : Creature
    {
        public Magmarex() : base("Magmarex", 5, 3000, Subtype.RockBeast, Civilization.Fire)
        {
            AddShieldTrigger();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new DestroyAllCreaturesThatHaveExactPower(1000));
        }
    }
}
