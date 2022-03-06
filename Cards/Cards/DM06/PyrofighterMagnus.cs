using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM06
{
    class PyrofighterMagnus : Creature
    {
        public PyrofighterMagnus() : base("Pyrofighter Magnus", 3, 3000, Common.Subtype.Dragonoid, Common.Civilization.Fire)
        {
            AddAbilities(new SpeedAttackerAbility());
            // At the end of your turn, return this creature to your hand.
            AddAbilities(new AtTheEndOfYourTurnAbility(new ReturnThisCreatureToYourHandEffect()));
        }
    }
}
