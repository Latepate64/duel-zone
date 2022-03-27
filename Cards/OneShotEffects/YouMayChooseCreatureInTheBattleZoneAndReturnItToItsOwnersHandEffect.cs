using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect : BounceEffect
    {
        public YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect() : base(0, 1, new CardFilters.BattleZoneChoosableCreatureFilter())
        {
        }

        public override OneShotEffect Copy()
        {
            return new YouMayChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect();
        }

        public override string ToString()
        {
            return "You may choose a creature in the battle zone and return it to its owner's hand.";
        }
    }
}