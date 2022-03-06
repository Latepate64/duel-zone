using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM12
{
    class WindmillMutant : Creature
    {
        public WindmillMutant() : base("Windmill Mutant", 3, Common.Civilization.Darkness, 2000, Common.Subtype.Hedrian)
        {
            // Whenever this creature attacks, you opponent discards a card at random from his hand.
            Abilities.Add(new AttackAbility(new OpponentRandomDiscardEffect()));
        }
    }
}
