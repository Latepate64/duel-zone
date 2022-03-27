using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect : BounceEffect
    {
        public YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect() : base(new CardFilters.BattleZoneChoosableCreatureFilter(), 0, 1)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect();
        }

        public override string ToString()
        {
            return "You may choose a creature in the battle zone and return it to its owner's hand.";
        }
    }
}