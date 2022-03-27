using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM02
{
    class MagrisVizierOfMagnetism : Creature
    {
        public MagrisVizierOfMagnetism() : base("Magris, Vizier of Magnetism", 4, 3000, Common.Subtype.Initiate, Common.Civilization.Light)
        {
            // When you put this creature into the battle zone, you may draw a card.
            AddAbilities(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new YouMayDrawCardsEffect(1)));
        }
    }
}
