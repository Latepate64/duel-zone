using Common;

namespace Cards.Cards.DM07
{
    class AquaFencer : Creature
    {
        public AquaFencer() : base("Aqua Fencer", 7, 3000, Subtype.LiquidPeople, Civilization.Water)
        {
            AddTapAbility(new OneShotEffects.ChooseCardInYourOpponentsManaZoneAndReturnItToHisHandEffect());
        }
    }
}
