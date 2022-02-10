using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM03
{
    public class SniperMosquito : Creature
    {
        public SniperMosquito() : base("Sniper Mosquito", 1, Common.Civilization.Nature, 2000, Common.Subtype.GiantInsect)
        {
            // Whenever this creature attacks, return a card from your mana zone to your hand.
            Abilities.Add(new WheneverThisCreatureAttacksAbility(new ManaRecoveryEffect(new OwnersManaZoneCardFilter(), 1, 1, true)));
        }
    }
}
