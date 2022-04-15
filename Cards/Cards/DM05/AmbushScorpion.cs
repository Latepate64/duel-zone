using Cards.OneShotEffects;

namespace Cards.Cards.DM05
{
    class AmbushScorpion : Creature
    {
        public AmbushScorpion() : base("Ambush Scorpion", 5, 3000, Engine.Subtype.GiantInsect, Engine.Civilization.Nature)
        {
            AddPowerAttackerAbility(3000);
            AddWhenThisCreatureIsDestroyedAbility(new YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect(Name));
        }
    }
}
