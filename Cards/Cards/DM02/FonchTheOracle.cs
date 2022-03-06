using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM02
{
    class FonchTheOracle : Creature
    {
        public FonchTheOracle() : base("Fonch, the Oracle", 4, 2000, Common.Subtype.LightBringer, Common.Civilization.Light)
        {
            // When you put this creature into the battle zone, you may choose one of your opponent's creatures in the battle zone and tap it.
            AddAbilities(new PutIntoPlayAbility(new TapChoiceEffect(0, 1, true)));
        }
    }
}
