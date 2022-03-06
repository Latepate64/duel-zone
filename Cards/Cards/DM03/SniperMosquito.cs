using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM03
{
    class SniperMosquito : Creature
    {
        public SniperMosquito() : base("Sniper Mosquito", 1, 2000, Common.Subtype.GiantInsect, Common.Civilization.Nature)
        {
            // Whenever this creature attacks, return a card from your mana zone to your hand.
            AddAbilities(new AttackAbility(new ManaRecoveryEffect(new OwnersManaZoneCardFilter(), 1, 1, true)));
        }
    }
}
