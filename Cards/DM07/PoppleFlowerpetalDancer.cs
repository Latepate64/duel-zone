using Engine.Abilities;

namespace Cards.DM07
{
    sealed class PoppleFlowerpetalDancer : Engine.Creature
    {
        public PoppleFlowerpetalDancer() : base("Popple, Flowerpetal Dancer", 4, 2000, Interfaces.Race.SnowFaerie, Interfaces.Civilization.Nature)
        {
            AddAbilities(new TapAbility(new OneShotEffects.PutTopCardOfDeckIntoManaZoneEffect()));
        }
    }
}
