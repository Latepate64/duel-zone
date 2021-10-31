using DuelMastersCards.Resolvables;
using DuelMastersCards.TriggeredAbilities;

namespace DuelMastersCards.Cards
{
    public class AquaSurfer : Creature
    {
        public AquaSurfer() : base("Aqua Surfer", 6, DuelMastersModels.Civilization.Water, 2000, DuelMastersModels.Subtype.LiquidPeople)
        {
            ShieldTrigger = true;
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new AquaSurferResolvable(1)));
        }
    }
}
