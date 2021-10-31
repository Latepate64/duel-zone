using DuelMastersCards.Resolvables;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class ArtisanPicora : Creature
    {
        public ArtisanPicora() : base("Artisan Picora", 1, Civilization.Fire, 2000, Subtype.MachineEater)
        {
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new PutCardsFromManaZoneIntoGraveyardResolvable(1, 1)));
        }
    }
}
