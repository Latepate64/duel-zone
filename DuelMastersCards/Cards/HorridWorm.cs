using DuelMastersCards.Resolvables;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class HorridWorm : Creature
    {
        public HorridWorm() : base("Horrid Worm", 3, Civilization.Darkness, 2000, Subtype.ParasiteWorm)
        {
            Abilities.Add(new WheneverThisCreatureAttacksAbility(new OpponentRandomDiscardResolvable()));
        }
    }
}
