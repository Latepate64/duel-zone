using Common;

namespace Cards.Cards.DM06
{
    class CrazeValkyrieTheDrastic : EvolutionCreature
    {
        public CrazeValkyrieTheDrastic() : base("Craze Valkyrie, the Drastic", 6, 7500, Subtype.Initiate, Civilization.Light)
        {
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.ChooseUpTo2OfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect()), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}