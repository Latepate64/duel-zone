using Common;

namespace Cards.Cards.DM03
{
    class AquaDeformer : Creature
    {
        public AquaDeformer() : base("Aqua Deformer", 8, 3000, Subtype.LiquidPeople, Civilization.Water)
        {
            // When you put this creature into the battle zone, return 2 cards from your mana zone to your hand. Then your opponent chooses 2 cards in his mana zone and returns them to his hand.
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.MutualManaRecoveryEffect(2)));
        }
    }
}
