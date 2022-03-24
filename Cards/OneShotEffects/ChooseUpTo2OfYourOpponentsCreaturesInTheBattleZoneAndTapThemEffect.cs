using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ChooseUpTo2OfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect : TapChoiceEffect
    {
        public ChooseUpTo2OfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect() : base(0, 2, true)
        {
        }

        public override OneShotEffect Copy()
        {
            return new ChooseUpTo2OfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect();
        }

        public override string ToString()
        {
            return "Choose up to 2 of your opponent's creatures in the battle zone and tap them.";
        }
    }
}
