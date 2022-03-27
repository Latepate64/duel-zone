using Common;

namespace Cards.Cards.DM07
{
    class PoppleFlowerpetalDancer : Creature
    {
        public PoppleFlowerpetalDancer() : base("Popple, Flowerpetal Dancer", 4, 2000, Subtype.SnowFaerie, Civilization.Nature)
        {
            AddAbilities(new Engine.Abilities.TapAbility(new OneShotEffects.PutTopCardsOfDeckIntoManaZoneEffect(1)));
        }
    }
}
