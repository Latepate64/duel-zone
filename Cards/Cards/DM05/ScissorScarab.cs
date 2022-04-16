namespace Cards.Cards.DM05
{
    class ScissorScarab : Creature
    {
        public ScissorScarab() : base("Scissor Scarab", 7, 5000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchRaceCreatureEffect(Engine.Race.GiantInsect));
        }
    }
}
