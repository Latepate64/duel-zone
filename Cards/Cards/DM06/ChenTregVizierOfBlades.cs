using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class ChenTregVizierOfBlades : Engine.Creature
    {
        public ChenTregVizierOfBlades() : base("Chen Treg, Vizier of Blades", 5, 2000, Engine.Race.Initiate, Engine.Civilization.Light)
        {
            AddAbilities(new TapAbility(new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect()));
        }
    }
}