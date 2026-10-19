using TriggeredAbilities;
using OneShotEffects;
using Interfaces;

namespace Cards.DM04;

sealed class MongrelMan : Creature
{
    public MongrelMan() : base("Mongrel Man", 5, 2000, Race.Hedrian,
        Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WheneverAnotherCreatureIsDestroyedAbility(
                new YouMayDrawCardsEffect(1)));
    }
}