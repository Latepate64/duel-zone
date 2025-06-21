using TriggeredAbilities;

namespace Cards.DM11
{
    class HeartyCapnPolligon : Engine.Creature
    {
        public HeartyCapnPolligon() : base("Hearty Cap'n Polligon", 1, 2000, Interfaces.Race.SnowFaerie, Interfaces.Civilization.Nature)
        {
            AddTriggeredAbility(new HeartyCapnPolligonAbility());
        }
    }
}
