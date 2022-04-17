using Cards.OneShotEffects;

namespace Cards.Cards.DM09
{
    class AbductionCharger : Charger
    {
        public AbductionCharger() : base("Abduction Charger", 7, Engine.Civilization.Water)
        {
            AddSpellAbilities(new ChooseUpTo2CreaturesInTheBattleZoneAndReturnThemToTheirOwnersHandsEffect());
        }
    }
}