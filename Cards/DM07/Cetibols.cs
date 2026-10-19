using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM07;

sealed class Cetibols : Creature
{
    public Cetibols() : base("Cetibols", 3, 2000, Race.SeaHacker, Civilization.Water)
    {
        AddTriggeredAbility(
            new WhenThisCreatureIsDestroyedAbility(
                new YouMayDrawCardsEffect(1)));
    }
}