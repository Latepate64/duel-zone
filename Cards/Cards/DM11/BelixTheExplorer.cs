using Cards.StaticAbilities;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM11
{
    class BelixTheExplorer : Creature
    {
        public BelixTheExplorer() : base("Belix, the Explorer", 2, Civilization.Light, 3000, Subtype.Gladiator)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new PutIntoPlayAbility(new OneShotEffects.ManaRecoveryEffect(new CardFilters.OwnersManaZoneCardFilter { CardType = CardType.Spell }, 1, 1, true)));
            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
