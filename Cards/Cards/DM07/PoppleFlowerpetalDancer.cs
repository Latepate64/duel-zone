using Engine.Abilities;

namespace Cards.Cards.DM07
{
    class PoppleFlowerpetalDancer : Engine.Creature
    {
        public PoppleFlowerpetalDancer() : base("Popple, Flowerpetal Dancer", 4, 2000, Engine.Race.SnowFaerie, Engine.Civilization.Nature)
        {
            AddAbilities(new TapAbility(new OneShotEffects.PutTopCardOfDeckIntoManaZoneEffect()));
        }
    }
}
