using Abilities.Static;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM06
{
    sealed class PyrofighterMagnus : Creature
    {
        public PyrofighterMagnus() : base("Pyrofighter Magnus", 3, 3000, Interfaces.Race.Dragonoid, Interfaces.Civilization.Fire)
        {
            AddAbilities(new SpeedAttackerAbility());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new ReturnThisCreatureToYourHandEffect()));
        }
    }
}
