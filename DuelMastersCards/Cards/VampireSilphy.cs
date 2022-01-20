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
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new DestroyCreaturesEffect(new CreaturesWithMaxPowerFilter(3000))));
        }
    }
}
