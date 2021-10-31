using DuelMastersCards.Resolvables;
using DuelMastersCards.StaticAbilities;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class ExplosiveFighterUcarn : Creature
    {
        public ExplosiveFighterUcarn() : base("Explosive Fighter Ucarn", 5, Civilization.Fire, 9000, Subtype.Dragonoid)
        {
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PutCardsFromManaZoneIntoGraveyardResolvable(2, 2)));
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
