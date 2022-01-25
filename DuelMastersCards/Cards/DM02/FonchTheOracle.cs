using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM02
{
    class FonchTheOracle : Creature
    {
        public FonchTheOracle() : base("Fonch, the Oracle", 4, Civilization.Light, 2000, Subtype.LightBringer)
        {
            // When you put this creature into the battle zone, you may choose one of your opponent's creatures in the battle zone and tap it.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new TapChoiceEffect(new OpponentsBattleZoneChoosableCreatureFilter(), 0, 1, true)));
        }
    }
}
