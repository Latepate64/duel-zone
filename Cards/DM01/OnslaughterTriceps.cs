using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM01
{
    class OnslaughterTriceps : Engine.Creature
    {
        public OnslaughterTriceps() : base("Onslaughter Triceps", 3, 5000, Interfaces.Race.Dragonoid, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PutCardsFromYourManaZoneIntoYourGraveyard(1)));
        }
    }
}
