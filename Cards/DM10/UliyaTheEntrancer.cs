using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM10;

sealed class UliyaTheEntrancer : Creature
{
    public UliyaTheEntrancer() : base("Uliya, the Entrancer", 6, 5000,
        Race.DarkLord, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenYouPutThisCreatureIntoTheBattleZoneAbility(
                new ShieldRecoveryEffect(
                    minimum: 1,
                    maximum: 1, 
                    controllerChooses: true, 
                    canUseShieldTrigger: true)));
    }
}