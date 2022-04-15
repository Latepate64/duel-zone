using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class OnslaughterTriceps : Creature
    {
        public OnslaughterTriceps() : base("Onslaughter Triceps", 3, 5000, Engine.Subtype.Dragonoid, Common.Civilization.Fire)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new PutCardsFromYourManaZoneIntoYourGraveyard(1));
        }
    }
}
