using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect : BounceEffect
    {
        public ChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect() : base(1, 1, new CardFilters.BattleZoneChoosableCreatureFilter())
        {
        }

        public override OneShotEffect Copy()
        {
            return new ChooseCreatureInTheBattleZoneAndReturnItToItsOwnersHandEffect();
        }

        public override string ToString()
        {
            return "Choose a creature in the battle zone and return it to its owner's hand.";
        }
    }
}
