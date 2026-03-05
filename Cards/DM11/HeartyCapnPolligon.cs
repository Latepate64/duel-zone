using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM11
{
    sealed class HeartyCapnPolligon : Creature
    {
        public HeartyCapnPolligon() : base("Hearty Cap'n Polligon", 1, 2000, Interfaces.Race.SnowFaerie, Interfaces.Civilization.Nature)
        {
            AddTriggeredAbility(new HeartyCapnPolligonAbility(new HeartyCapnPolligonEffect()));
        }
    }
}
