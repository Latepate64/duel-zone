using Cards.TriggeredAbilities;

namespace Cards.Cards.DM11
{
    class HeartyCapnPolligon : Creature
    {
        public HeartyCapnPolligon() : base("Hearty Cap'n Polligon", 1, 2000, Engine.Subtype.SnowFaerie, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new HeartyCapnPolligonAbility());
        }
    }
}
