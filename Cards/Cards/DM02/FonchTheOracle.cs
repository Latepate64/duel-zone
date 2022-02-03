using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM02
{
    class FonchTheOracle : Creature
    {
        public FonchTheOracle() : base("Fonch, the Oracle", 4, Common.Civilization.Light, 2000, Common.Subtype.LightBringer)
        {
            // When you put this creature into the battle zone, you may choose one of your opponent's creatures in the battle zone and tap it.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new TapChoiceEffect(new OpponentsBattleZoneChoosableCreatureFilter(), 0, 1, true)));
        }
    }
}
