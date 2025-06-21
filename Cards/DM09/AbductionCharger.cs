using OneShotEffects;

namespace Cards.DM09
{
    class AbductionCharger : Charger
    {
        public AbductionCharger() : base("Abduction Charger", 7, Interfaces.Civilization.Water)
        {
            AddSpellAbilities(new ChooseUpTo2CreaturesInTheBattleZoneAndReturnThemToTheirOwnersHandsEffect());
        }
    }
}