using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM11
{
    public class HeartyCapnPolligon : Creature
    {
        public HeartyCapnPolligon() : base("Hearty Cap'n Polligon", 1, Civilization.Nature, 2000, Subtype.SnowFaerie)
        {
            // At the end of each of your turns, if this creature broke any shields that turn, return it to your hand.
            Abilities.Add(new HeartyCapnPolligonAbility(new HeartyCapnPolligonEffect()));
        }
    }
}
