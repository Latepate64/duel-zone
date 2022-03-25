using Cards.OneShotEffects;
using Common;

namespace Cards.Cards.DM09
{
    class AbductionCharger : Charger
    {
        public AbductionCharger() : base("Abduction Charger", 7, Civilization.Water)
        {
            AddSpellAbilities(new ChooseUpTo2CreaturesInTheBattleZoneAndReturnThemToTheirOwnersHandsEffect());
        }
    }
}