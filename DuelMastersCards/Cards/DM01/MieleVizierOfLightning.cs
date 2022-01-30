using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM01
{
    class MieleVizierOfLightning : Creature
    {
        public MieleVizierOfLightning() : base("Miele, Vizier of Lightning", 3, Civilization.Light, 1000, Subtype.Initiate)
        {
            // When you put this creature into the battle zone, you may choose 1 of your opponent's creatures in the battle zone and tap it.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new TapChoiceEffect(new OpponentsBattleZoneChoosableCreatureFilter(), 0, 1, true)));
        }
    }
}
