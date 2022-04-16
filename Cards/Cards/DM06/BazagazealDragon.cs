using Cards.OneShotEffects;

namespace Cards.Cards.DM06
{
    class BazagazealDragon : Creature
    {
        public BazagazealDragon() : base("Bazagazeal Dragon", 8, 8000, Engine.Race.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddSpeedAttackerAbility();
            AddThisCreatureCanAttackUntappedCreaturesAbility();
            AddDoubleBreakerAbility();
            AddAtTheEndOfYourTurnAbility(new ReturnThisCreatureToYourHandEffect());
        }
    }
}
