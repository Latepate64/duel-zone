using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine;

namespace Cards.Cards.DM12
{
    public class WindmillMutant : Creature
    {
        public WindmillMutant() : base("Windmill Mutant", 3, Civilization.Darkness, 2000, Subtype.Hedrian)
        {
            // Whenever this creature attacks, you opponent discards a card at random from his hand.
            Abilities.Add(new WheneverThisCreatureAttacksAbility(new OpponentRandomDiscardEffect()));
        }
    }
}
