namespace Cards.Cards.DM11
{
    class HazardHopper : Creature
    {
        public HazardHopper() : base("Hazard Hopper", 4, 5000, Engine.Subtype.GiantInsect, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new TriggeredAbilities.HeartyCapnPolligonAbility());
        }
    }
}
