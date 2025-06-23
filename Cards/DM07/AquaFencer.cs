using Abilities;

namespace Cards.DM07
{
    sealed class AquaFencer : Creature
    {
        public AquaFencer() : base("Aqua Fencer", 7, 3000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddAbilities(new TapAbility(new OneShotEffects.ChooseCardInYourOpponentsManaZoneAndReturnItToHisHandEffect()));
        }
    }
}
