using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    public class ManaCrisis : Spell
    {
        public ManaCrisis() : base("Mana Crisis", 4, Civilization.Nature)
        {
            ShieldTrigger = true;
            Abilities.Add(new SpellAbility(new PutCardsFromManaZoneIntoGraveyardEffect(1, 1, ZoneOwner.Opponent)));
        }
    }
}
