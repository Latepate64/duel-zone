using DuelMastersCards.Resolvables;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class UnicornFish : Creature
    {
        public UnicornFish() : base("Unicorn Fish", 4, Civilization.Water, 1000, Subtype.Fish)
        {
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new AquaSurferResolvable(1)));
        }
    }
}
