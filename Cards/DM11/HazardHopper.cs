using TriggeredAbilities;

namespace Cards.DM11
{
    sealed class HazardHopper : Engine.Creature
    {
        public HazardHopper() : base("Hazard Hopper", 4, 5000, Interfaces.Race.GiantInsect, Interfaces.Civilization.Nature)
        {
            AddTriggeredAbility(new HeartyCapnPolligonAbility());
        }
    }
}
