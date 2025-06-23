using Engine.Abilities;

namespace Cards.DM06
{
    sealed class ChenTregVizierOfBlades : Creature
    {
        public ChenTregVizierOfBlades() : base("Chen Treg, Vizier of Blades", 5, 2000, Interfaces.Race.Initiate, Interfaces.Civilization.Light)
        {
            AddAbilities(new TapAbility(new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect()));
        }
    }
}