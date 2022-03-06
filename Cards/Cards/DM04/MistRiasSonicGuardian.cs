using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM04
{
    class MistRiasSonicGuardian : Creature
    {
        public MistRiasSonicGuardian() : base("Mist Rias, Sonic Guardian", 5, 2000, Common.Subtype.Guardian, Common.Civilization.Light)
        {
            // Whenever another creature is put into the battle zone, you may draw a card.
            Abilities.Add(new PutIntoPlayAbility(new ControllerMayDrawCardsEffect(1), new CardFilters.AnotherBattleZoneCreatureFilter()));
        }
    }
}
