using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM08;

sealed class BruiserDragon : Creature
{
    public BruiserDragon() : base("Bruiser Dragon", 5, 5000, Race.ArmoredDragon,
        Civilization.Fire)
    {
        AddTriggeredAbility(
            new WhenThisCreatureIsDestroyedAbility(
                new ShieldBurnEffect(
                    minimum: 1,
                    maximum: 1,
                    ownShields: true
        )));
    }
}