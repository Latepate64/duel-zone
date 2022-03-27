using Common;

namespace Cards.Cards.DM07
{
    class FruitOfEternity : Spell
    {
        public FruitOfEternity() : base("Fruit of Eternity", 4, Civilization.Nature)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new OneShotEffects.WheneverAnyOfYourCreaturesWouldBeDestroyedThisTurnPutItIntoYourManaZoneInsteadEffect());
        }
    }
}
