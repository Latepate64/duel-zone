using Cards.CardFilters;
using Cards.OneShotEffects;

namespace Cards.Cards.DM02
{
    class ManaCrisis : Spell
    {
        public ManaCrisis() : base("Mana Crisis", 4, Common.Civilization.Nature)
        {
            ShieldTrigger = true;
            // Choose a card in your opponent's mana zone and put it into his graveyard.
            AddSpellAbilities(new ManaBurnEffect(new OpponentsManaZoneCardFilter(), 1, 1, true));
        }
    }
}
