using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class OnslaughterTriceps : Creature
    {
        public OnslaughterTriceps() : base("Onslaughter Triceps", 3, 5000, Common.Subtype.Dragonoid, Common.Civilization.Fire)
        {
            AddAbilities(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PutCardsFromYourManaZoneIntoYourGraveyard(1)));
        }
    }
}
