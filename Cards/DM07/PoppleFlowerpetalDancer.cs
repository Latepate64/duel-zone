using Abilities;
using Interfaces;
using OneShotEffects;

namespace Cards.DM07;

sealed class PoppleFlowerpetalDancer : Creature
{
    public PoppleFlowerpetalDancer() : base("Popple, Flowerpetal Dancer", 4,
        2000, Race.SnowFaerie, Civilization.Nature)
    {
        AddAbilities(
            new TapAbility(
                new PutTopCardsOfDeckIntoManaZoneEffect(1)));
    }
}