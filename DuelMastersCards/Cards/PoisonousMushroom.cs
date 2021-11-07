using DuelMastersCards.Resolvables;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class PoisonousMushroom : Creature
    {
        public PoisonousMushroom() : base("Poisonous Mushroom", 2, Civilization.Nature, 1000, Subtype.BalloonMushroom)
        {
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PutCardsFromHandIntoManaZoneResolvable(1)));
        }
    }
}
