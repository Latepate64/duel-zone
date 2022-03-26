using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect : BounceEffect
    {
        public ChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect() : base(new CardFilters.BattleZoneChoosableCreatureFilter(), 1, 1)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect();
        }

        public override string ToString()
        {
            return "Choose a creature in the battle zone and return it to its owner's hand.";
        }
    }
}
