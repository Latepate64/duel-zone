using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM05
{
    class ScissorScarab : Engine.Creature
    {
        public ScissorScarab() : base("Scissor Scarab", 7, 5000, Interfaces.Race.GiantInsect, Interfaces.Civilization.Nature)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SearchRaceCreatureEffect(Interfaces.Race.GiantInsect)));
        }
    }
}
