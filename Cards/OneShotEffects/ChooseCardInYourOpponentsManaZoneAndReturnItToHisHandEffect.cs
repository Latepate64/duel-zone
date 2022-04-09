using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class ChooseCardInYourOpponentsManaZoneAndReturnItToHisHandEffect : OpponentManaRecoveryEffect
    {
        public ChooseCardInYourOpponentsManaZoneAndReturnItToHisHandEffect() : base(1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ChooseCardInYourOpponentsManaZoneAndReturnItToHisHandEffect();
        }

        public override string ToString()
        {
            return "Choose a card in your opponent's mana zone and return it to his hand.";
        }
    }
}
