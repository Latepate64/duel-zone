using Common;

namespace Cards.Cards.DM12
{
    class WilyCarpenter : Creature
    {
        public WilyCarpenter() : base("Wily Carpenter", 3, 1000, Subtype.Merfolk, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.DrawThenDiscardEffect(2));
        }
    }
}
