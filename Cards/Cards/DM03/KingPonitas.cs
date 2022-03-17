using Common;

namespace Cards.Cards.DM03
{
    class KingPonitas : Creature
    {
        public KingPonitas() : base("King Ponitas", 8, 4000, Subtype.Leviathan, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.AttackAbility(new OneShotEffects.TutoringEffect(new CardFilters.OwnersDeckCivilizationCardFilter(Civilization.Water), true)));
        }
    }
}
