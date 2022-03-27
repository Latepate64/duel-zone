using Common;

namespace Cards.Cards.DM05
{
    class ScissorScarab : Creature
    {
        public ScissorScarab() : base("Scissor Scarab", 7, 5000, Subtype.GiantInsect, Civilization.Nature)
        {
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.TutoringEffect(new CardFilters.SubtypeFilter(Subtype.GiantInsect), true)));
        }
    }
}
