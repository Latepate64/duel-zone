using Cards.CardFilters;
using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    public class ManaCrisis : Spell
    {
        public ManaCrisis() : base("Mana Crisis", 4, Civilization.Nature)
        {
            ShieldTrigger = true;
            // Choose a card in your opponent's mana zone and put it into his graveyard.
            Abilities.Add(new SpellAbility(new ManaBurnEffect(new OpponentsManaZoneCardFilter(), 1, 1, true)));
        }
    }
}
