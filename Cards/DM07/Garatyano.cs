using OneShotEffects;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM07;

sealed class Garatyano : Creature
{
    public Garatyano() : base("Garatyano", 4, 2000, Race.SeaHacker, Civilization.Water)
    {
        AddAbilities(new TapAbility(
            new LookAtTheTopCardsOfYourDeckAndPutBackInAnyOrderEffect(3)));
    }
}
