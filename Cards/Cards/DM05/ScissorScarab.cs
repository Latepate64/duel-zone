namespace Cards.Cards.DM05
{
    class ScissorScarab : Creature
    {
        public ScissorScarab() : base("Scissor Scarab", 7, 5000, Engine.Subtype.GiantInsect, Engine.Civilization.Nature)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchSubtypeCreatureEffect(Engine.Subtype.GiantInsect));
        }
    }
}
