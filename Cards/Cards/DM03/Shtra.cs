using Common;

namespace Cards.Cards.DM03
{
    class Shtra : Creature
    {
        public Shtra() : base("Shtra", 4, 2000, Subtype.CyberLord, Civilization.Water)
        {
            // When you put this creature into the battle zone, return a card from your mana zone to your hand. Then your opponent chooses a card in his mana zone and returns it to his hand.
            Abilities.Add(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.ShtraEffect(1)));
        }
    }
}
