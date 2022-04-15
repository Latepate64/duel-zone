using Cards.OneShotEffects;
using Common;

namespace Cards.Cards.DM05
{
    class AmbushScorpion : Creature
    {
        public AmbushScorpion() : base("Ambush Scorpion", 5, 3000, Engine.Subtype.GiantInsect, Civilization.Nature)
        {
            AddPowerAttackerAbility(3000);
            AddWhenThisCreatureIsDestroyedAbility(new YouMayPutCardWithNameFromYourManaZoneIntoTheBattleZoneEffect(Name));
        }
    }
}
