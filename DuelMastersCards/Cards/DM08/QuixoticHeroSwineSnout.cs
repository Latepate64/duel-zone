using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class QuixoticHeroSwineSnout : Creature
    {
        public QuixoticHeroSwineSnout() : base("Quixotic Hero Swine Snout", 2, Civilization.Nature, 1000, Subtype.BeastFolk)
        {
            // Whenever another creature is put into the battle zone, this creature gets +3000 power until the end of the turn.
            Abilities.Add(new AnotherCreaturePutIntoBattleZoneAbility(new QuixoticHeroSwineSnoutEffect()));
        }
    }
}
