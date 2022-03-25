using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class AquaSniper : Creature
    {
        public AquaSniper() : base("Aqua Sniper", 8, 5000, Common.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            AddAbilities(new PutIntoPlayAbility(new ChooseUpTo2CreaturesInTheBattleZoneAndReturnThemToTheirOwnersHandsEffect()));
        }
    }
}
