using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02;

sealed class HypersquidWalter : Creature
{
    public HypersquidWalter() : base("Hypersquid Walter", 3, 1000,
        Race.CyberLord, Civilization.Water)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new YouMayDrawCardsEffect(1)));
    }
}