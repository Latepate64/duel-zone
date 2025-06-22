using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM08
{
    sealed class MotorcycleMutant : Engine.Creature
    {
        public MotorcycleMutant() : base("Motorcycle Mutant", 4, 6000, Interfaces.Race.Hedrian, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
            AddTriggeredAbility(new WhenYouPutAnotherCreatureIntoTheBattleZoneAbility(new OneShotEffects.DestroyThisCreatureEffect()));
        }
    }
}
