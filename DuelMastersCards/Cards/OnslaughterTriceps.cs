using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class OnslaughterTriceps : Creature
    {
        public OnslaughterTriceps() : base("Onslaughter Triceps", 3, Civilization.Fire, 5000, Subtype.Dragonoid)
        {
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PutCardsFromManaZoneIntoGraveyardEffect(1, 1, ZoneOwner.Controller)));
        }
    }
}
