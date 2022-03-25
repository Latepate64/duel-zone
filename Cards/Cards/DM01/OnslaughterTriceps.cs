using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class OnslaughterTriceps : Creature
    {
        public OnslaughterTriceps() : base("Onslaughter Triceps", 3, 5000, Common.Subtype.Dragonoid, Common.Civilization.Fire)
        {
            // When you put this creature into the battle zone, put 1 card from your mana zone into your graveyard.
            AddAbilities(new WhenThisCreatureIsPutIntoTheBattleZoneAbility(new SelfManaBurnEffect(1)));
        }
    }
}
