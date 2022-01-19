using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class QuixoticHeroSwineSnout : Creature
    {
        public QuixoticHeroSwineSnout() : base("Quixotic Hero Swine Snout", 2, Civilization.Nature, 1000, Subtype.BeastFolk)
        {
            Abilities.Add(new AnotherCreaturePutIntoBattleZoneAbility(new QuixoticHeroSwineSnoutEffect()));
        }
    }
}
