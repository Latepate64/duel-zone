using TriggeredAbilities;
using OneShotEffects;
using Abilities.Static;

namespace Cards.DM01
{
    sealed class ExplosiveFighterUcarn : Creature
    {
        public ExplosiveFighterUcarn() : base("Explosive Fighter Ucarn", 5, 9000, Interfaces.Race.Dragonoid, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PutCardsFromYourManaZoneIntoYourGraveyard(2)));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
