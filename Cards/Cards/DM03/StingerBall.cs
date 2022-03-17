using Common;

namespace Cards.Cards.DM03
{
    class StingerBall : Creature
    {
        public StingerBall() : base("Stinger Ball", 3, 1000, Subtype.CyberVirus, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.AttackAbility(new OneShotEffects.LookEffect(new CardFilters.OpponentsShieldZoneCardFilter(), 0, 1, true)));
        }
    }
}
