using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM02
{
    public class MagrisVizierOfMagnetism : Creature
    {
        public MagrisVizierOfMagnetism() : base("Magris, Vizier of Magnetism", 4, Common.Civilization.Light, 3000, Common.Subtype.Initiate)
        {
            // When you put this creature into the battle zone, you may draw a card.
            Abilities.Add(new PutIntoPlayAbility(new ControllerMayDrawCardsEffect(1)));
        }
    }
}
