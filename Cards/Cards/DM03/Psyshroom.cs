using Cards.OneShotEffects;

namespace Cards.Cards.DM03
{
    class Psyshroom : Creature
    {
        public Psyshroom() : base("Psyshroom", 4, 2000, Common.Subtype.BalloonMushroom, Common.Civilization.Nature)
        {
            // Whenever this creature attacks, you may put a nature card from your graveyard into your mana zone.
            Abilities.Add(new TriggeredAbilities.AttackAbility(new FromGraveyardIntoManaZoneEffect(new CardFilters.OwnersGraveyardCardFilter(Common.Civilization.Nature), 0, 1, true)));
        }
    }
}
