using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM06
{
    sealed class CrazeValkyrieTheDrastic : EvolutionCreature
    {
        public CrazeValkyrieTheDrastic() : base("Craze Valkyrie, the Drastic", 6, 7500, Interfaces.Race.Initiate, Interfaces.Civilization.Light)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}