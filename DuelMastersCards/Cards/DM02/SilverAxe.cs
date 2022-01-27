using DuelMastersModels;

namespace DuelMastersCards.Cards.DM02
{
    class SilverAxe : Creature
    {
        public SilverAxe() : base("Silver Axe", 3, Civilization.Nature, 1000, Subtype.BeastFolk)
        {
            // Whenever this creature attacks, you may put the top card of your deck into your mana zone.
            Abilities.Add(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.MayPutTopCardOfDeckIntoManaZoneEffect()));
        }
    }
}
