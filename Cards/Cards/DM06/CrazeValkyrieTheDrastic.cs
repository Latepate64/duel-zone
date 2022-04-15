using Common;

namespace Cards.Cards.DM06
{
    class CrazeValkyrieTheDrastic : EvolutionCreature
    {
        public CrazeValkyrieTheDrastic() : base("Craze Valkyrie, the Drastic", 6, 7500, Engine.Subtype.Initiate, Civilization.Light)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseUpToOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect(2));
            AddDoubleBreakerAbility();
        }
    }
}