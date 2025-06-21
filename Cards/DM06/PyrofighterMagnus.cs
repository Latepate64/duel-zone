using OneShotEffects;
using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM06
{
    class PyrofighterMagnus : Engine.Creature
    {
        public PyrofighterMagnus() : base("Pyrofighter Magnus", 3, 3000, Interfaces.Race.Dragonoid, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new ReturnThisCreatureToYourHandEffect()));
        }
    }
}
