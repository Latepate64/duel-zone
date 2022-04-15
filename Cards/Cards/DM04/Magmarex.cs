using Cards.OneShotEffects;

namespace Cards.Cards.DM04
{
    class Magmarex : Creature
    {
        public Magmarex() : base("Magmarex", 5, 3000, Engine.Subtype.RockBeast, Engine.Civilization.Fire)
        {
            AddShieldTrigger();
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new DestroyAllCreaturesThatHaveExactPower(1000));
        }
    }
}
