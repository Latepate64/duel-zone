using DuelMastersCards.OneShotEffects;
using DuelMastersCards.StaticAbilities;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class PyrofighterMagnus : Creature
    {
        public PyrofighterMagnus() : base("Pyrofighter Magnus", 3, Civilization.Fire, 3000, Subtype.Dragonoid)
        {
            Abilities.Add(new SpeedAttackerAbility());
            Abilities.Add(new AtTheEndOfYourTurnAbility(new PyrofighterMagnusEffect()));
        }
    }
}
