using Cards.OneShotEffects;
using Common;

namespace Cards.Cards.DM06
{
    class BazagazealDragon : Creature
    {
        public BazagazealDragon() : base("Bazagazeal Dragon", 8, 8000, Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddSpeedAttackerAbility();
            AddThisCreatureCanAttackUntappedCreaturesAbility();
            AddDoubleBreakerAbility();
            AddAtTheEndOfYourTurnAbility(new ReturnThisCreatureToYourHandEffect());
        }
    }
}
