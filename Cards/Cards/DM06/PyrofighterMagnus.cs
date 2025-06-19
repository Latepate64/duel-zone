using Cards.ContinuousEffects;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Effects.Continuous;

namespace Cards.Cards.DM06
{
    class PyrofighterMagnus : Engine.Creature
    {
        public PyrofighterMagnus() : base("Pyrofighter Magnus", 3, 3000, Engine.Race.Dragonoid, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new ReturnThisCreatureToYourHandEffect()));
        }
    }
}
