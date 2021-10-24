using DuelMastersCards.Resolvables;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class SniperMosquito : Creature
    {
        public SniperMosquito() : base("Sniper Mosquito", 1, Civilization.Nature, 2000, Subtype.GiantInsect)
        {
            Abilities.Add(new WheneverThisCreatureAttacksAbility(new SniperMosquitoResolvable()));
        }
    }
}
