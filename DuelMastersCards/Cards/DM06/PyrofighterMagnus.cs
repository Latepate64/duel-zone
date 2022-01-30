using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM06
{
    public class PyrofighterMagnus : Creature
    {
        public PyrofighterMagnus() : base("Pyrofighter Magnus", 3, Civilization.Fire, 3000, Subtype.Dragonoid)
        {
            Abilities.Add(new SpeedAttackerAbility());
            // At the end of your turn, return this creature to your hand.
            Abilities.Add(new AtTheEndOfYourTurnAbility(new PyrofighterMagnusEffect()));
        }
    }
}
