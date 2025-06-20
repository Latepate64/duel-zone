using Cards.OneShotEffects;
using Abilities.Triggered;
using ContinuousEffects;

namespace Cards.Cards.DM06
{
    class BazagazealDragon : Engine.Creature
    {
        public BazagazealDragon() : base("Bazagazeal Dragon", 8, 8000, Engine.Race.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
            AddStaticAbilities(new DoubleBreakerEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new ReturnThisCreatureToYourHandEffect()));
        }
    }
}
