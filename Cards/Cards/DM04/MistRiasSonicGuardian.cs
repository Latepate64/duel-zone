using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM04
{
    class MistRiasSonicGuardian : Creature
    {
        public MistRiasSonicGuardian() : base("Mist Rias, Sonic Guardian", 5, 2000, Common.Subtype.Guardian, Common.Civilization.Light)
        {
            AddAbilities(new WheneverAnotherCreatureIsPutIntoTheBattleZoneAbility(new YouMayDrawCardsEffect(1)));
        }
    }
}
