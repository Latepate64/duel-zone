using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class MaskedHorrorShadowOfScorn : Creature
    {
        public MaskedHorrorShadowOfScorn() : base("Masked Horror, Shadow of Scorn", 5, 1000, Common.Subtype.Ghost, Common.Civilization.Darkness)
        {
            // When you put this creature into the battle zone, your opponent discards a card at random from his hand.
            Abilities.Add(new PutIntoPlayAbility(new OpponentRandomDiscardEffect()));
        }
    }
}
