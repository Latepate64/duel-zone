using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class OnslaughterTriceps : Engine.Creature
    {
        public OnslaughterTriceps() : base("Onslaughter Triceps", 3, 5000, Engine.Race.Dragonoid, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PutCardsFromYourManaZoneIntoYourGraveyard(1)));
        }
    }
}
