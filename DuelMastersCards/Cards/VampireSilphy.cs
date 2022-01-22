using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class VampireSilphy : Creature
    {
        public VampireSilphy() : base("Vampire Silphy", 8, Civilization.Darkness, 4000, Subtype.DarkLord)
        {
            // When you put this creature into the battle zone, destroy all creatures that have power 3000 or less.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DestroyCreaturesEffect(new CreaturesWithMaxPowerFilter(3000))));
        }
    }
}
