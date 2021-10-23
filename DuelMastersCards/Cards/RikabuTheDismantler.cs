using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class RikabuTheDismantler : Creature
    {
        public RikabuTheDismantler() : base("Rikabu, the Dismantler", 3, Civilization.Fire, 1000, Subtype.MachineEater)
        {
            Abilities.Add(new SpeedAttackerAbility());
        }
    }
}
