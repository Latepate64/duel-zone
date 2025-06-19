using Cards.ContinuousEffects;
using Cards.OneShotEffects;

namespace Cards.Cards.DM06
{
    class BazagazealDragon : Creature
    {
        public BazagazealDragon() : base("Bazagazeal Dragon", 8, 8000, Engine.Race.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
            AddStaticAbilities(new DoubleBreakerEffect());
            AddAtTheEndOfYourTurnAbility(new ReturnThisCreatureToYourHandEffect());
        }
    }
}
