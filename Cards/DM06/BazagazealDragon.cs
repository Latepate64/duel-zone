using Abilities.Static;
using ContinuousEffects.CanAttackUntappedCreatures;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM06
{
    sealed class BazagazealDragon : Creature
    {
        public BazagazealDragon() : base("Bazagazeal Dragon", 8, 8000, Interfaces.Race.ArmoredDragon, Interfaces.Civilization.Fire)
        {
            AddAbilities(new SpeedAttackerAbility());
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
            AddAbilities(new DoubleBreakerAbility());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new ReturnThisCreatureToYourHandEffect()));
        }
    }
}
