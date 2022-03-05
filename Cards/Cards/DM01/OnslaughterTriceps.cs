using Cards.CardFilters;
using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    public class OnslaughterTriceps : Creature
    {
        public OnslaughterTriceps() : base("Onslaughter Triceps", 3, Common.Civilization.Fire, 5000, Common.Subtype.Dragonoid)
        {
            // When you put this creature into the battle zone, put 1 card from your mana zone into your graveyard.
            Abilities.Add(new PutIntoPlayAbility(new ManaBurnEffect(new OwnersManaZoneCardFilter(), 1, 1, true)));
        }
    }
}
