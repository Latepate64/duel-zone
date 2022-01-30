using DuelMastersModels;

namespace Cards.Cards.DM02
{
    class DarkTitanMaginn : Creature
    {
        public DarkTitanMaginn() : base("Dark Titan Maginn", 6, Civilization.Darkness, 4000, Subtype.DemonCommand)
        {
            // Whenever this creature attacks, your opponent discards a card at random from his hand.
            Abilities.Add(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.OpponentRandomDiscardEffect()));
        }
    }
}
