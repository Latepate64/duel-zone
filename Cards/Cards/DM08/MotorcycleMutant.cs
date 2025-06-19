using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM08
{
    class MotorcycleMutant : Engine.Creature
    {
        public MotorcycleMutant() : base("Motorcycle Mutant", 4, 6000, Engine.Race.Hedrian, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddTriggeredAbility(new TriggeredAbilities.WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(new OneShotEffects.DestroyThisCreatureEffect()));
        }
    }
}
