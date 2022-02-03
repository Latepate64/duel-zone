using Cards.TriggeredAbilities;

namespace Cards.Cards.DM11
{
    public class HeartyCapnPolligon : Creature
    {
        public HeartyCapnPolligon() : base("Hearty Cap'n Polligon", 1, Common.Civilization.Nature, 2000, Common.Subtype.SnowFaerie)
        {
            // At the end of each of your turns, if this creature broke any shields that turn, return it to your hand.
            Abilities.Add(new HeartyCapnPolligonAbility(new HeartyCapnPolligonEffect()));
        }
    }
}
