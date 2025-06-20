using Abilities.Triggered;
using Effects.OneShot;

namespace Cards.Cards.DM05
{
    class ScissorScarab : Engine.Creature
    {
        public ScissorScarab() : base("Scissor Scarab", 7, 5000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SearchRaceCreatureEffect(Engine.Race.GiantInsect)));
        }
    }
}
