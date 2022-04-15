namespace Cards.Cards.DM06
{
    class ChenTregVizierOfBlades : Creature
    {
        public ChenTregVizierOfBlades() : base("Chen Treg, Vizier of Blades", 5, 2000, Engine.Subtype.Initiate, Engine.Civilization.Light)
        {
            AddTapAbility(new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect());
        }
    }
}