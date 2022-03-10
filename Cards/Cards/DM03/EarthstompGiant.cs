using Common;

namespace Cards.Cards.DM03
{
    class EarthstompGiant : Creature
    {
        public EarthstompGiant() : base("Earthstomp Giant", 5, 8000, Subtype.Giant, Civilization.Nature)
        {
            AddAbilities(new StaticAbilities.DoubleBreakerAbility(), new TriggeredAbilities.AttackAbility(new OneShotEffects.ManaRecoveryAreaOfEffect(new CardFilters.OwnersManaZoneCardFilter { CardType = CardType.Creature })));
        }
    }
}
