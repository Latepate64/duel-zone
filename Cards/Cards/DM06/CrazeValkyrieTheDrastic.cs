using Abilities.Triggered;
using Abilities.Triggered;
using Effects.Continuous;

namespace Cards.Cards.DM06
{
    class CrazeValkyrieTheDrastic : EvolutionCreature
    {
        public CrazeValkyrieTheDrastic() : base("Craze Valkyrie, the Drastic", 6, 7500, Engine.Race.Initiate, Engine.Civilization.Light)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}