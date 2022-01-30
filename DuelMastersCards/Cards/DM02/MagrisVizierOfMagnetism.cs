using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Engine;

namespace Cards.Cards.DM02
{
    public class MagrisVizierOfMagnetism : Creature
    {
        public MagrisVizierOfMagnetism() : base("Magris, Vizier of Magnetism", 4, Civilization.Light, 3000, Subtype.Initiate)
        {
            // When you put this creature into the battle zone, you may draw a card.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ControllerMayDrawCardsEffect(1)));
        }
    }
}
