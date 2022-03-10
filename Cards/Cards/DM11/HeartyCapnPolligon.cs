using Cards.TriggeredAbilities;

namespace Cards.Cards.DM11
{
    class HeartyCapnPolligon : Creature
    {
        public HeartyCapnPolligon() : base("Hearty Cap'n Polligon", 1, 2000, Common.Subtype.SnowFaerie, Common.Civilization.Nature)
        {
            // At the end of each of your turns, if this creature broke any shields that turn, return it to your hand.
            AddAbilities(new HeartyCapnPolligonAbility());
        }
    }
}
