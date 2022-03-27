using Common;

namespace Cards.Cards.DM07
{
    class MulchCharger : Charger
    {
        public MulchCharger() : base("Mulch Charger", 3, Civilization.Nature)
        {
            AddSpellAbilities(new OneShotEffects.PutOneOfYourCreaturesFromTheBattleZoneIntoYourManaZoneEffect());
        }
    }
}
