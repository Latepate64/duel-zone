using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM08
{
    class QuixoticHeroSwineSnout : Creature
    {
        public QuixoticHeroSwineSnout() : base("Quixotic Hero Swine Snout", 2, Common.Civilization.Nature, 1000, Common.Subtype.BeastFolk)
        {
            // Whenever another creature is put into the battle zone, this creature gets +3000 power until the end of the turn.
            Abilities.Add(new PutIntoPlayAbility(new QuixoticHeroSwineSnoutEffect(), new CardFilters.AnotherBattleZoneCreatureFilter()));
        }
    }
}
