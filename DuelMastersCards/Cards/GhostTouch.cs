using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class GhostTouch : Spell
    {
        public GhostTouch() : base("Ghost Touch", 2, Civilization.Darkness)
        {
            ShieldTrigger = true;
            Abilities.Add(new SpellAbility(new OpponentRandomDiscardEffect()));
        }
    }
}
