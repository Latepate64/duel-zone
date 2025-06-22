using OneShotEffects;
using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM06
{
    sealed class BazagazealDragon : Engine.Creature
    {
        public BazagazealDragon() : base("Bazagazeal Dragon", 8, 8000, Interfaces.Race.ArmoredDragon, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
            AddStaticAbilities(new DoubleBreakerEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new ReturnThisCreatureToYourHandEffect()));
        }
    }
}
