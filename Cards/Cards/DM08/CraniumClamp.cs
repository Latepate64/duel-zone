using Cards.CardFilters;
using Cards.OneShotEffects;
using Common;
using Engine.Abilities;

namespace Cards.Cards.DM08
{
    public class CraniumClamp : Spell
    {
        public CraniumClamp() : base("Cranium Clamp", 4, Common.Civilization.Darkness)
        {
            // Your opponent chooses and discards 2 cards from his hand.
            Abilities.Add(new SpellAbility(new CardMovingChoiceEffect(new OpponentsHandCardFilter(), 2, 2, false, ZoneType.Hand, ZoneType.Graveyard)));
        }
    }
}
