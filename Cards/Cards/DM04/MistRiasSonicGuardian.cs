using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM04
{
    public class MistRiasSonicGuardian : Creature
    {
        public MistRiasSonicGuardian() : base("Mist Rias, Sonic Guardian", 5, Common.Civilization.Light, 2000, Common.Subtype.Guardian)
        {
            // Whenever another creature is put into the battle zone, you may draw a card.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ControllerMayDrawCardsEffect(1), new CardFilters.AnotherBattleZoneCreatureFilter()));
        }
    }
}
