using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM06
{
    class BazagazealDragon : Creature
    {
        public BazagazealDragon() : base("Bazagazeal Dragon", 8, Civilization.Fire, 8000, Subtype.ArmoredDragon)
        {
            Abilities.Add(new SpeedAttackerAbility());
            Abilities.Add(new CanAttackUntappedCreaturesAbility());
            Abilities.Add(new DoubleBreakerAbility());
            Abilities.Add(new AtTheEndOfYourTurnAbility(new ReturnThisCreatureToYourHandEffect()));
        }
    }
}
