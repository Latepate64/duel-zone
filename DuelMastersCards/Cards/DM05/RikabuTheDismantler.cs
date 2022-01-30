using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM05
{
    public class RikabuTheDismantler : Creature
    {
        public RikabuTheDismantler() : base("Rikabu, the Dismantler", 3, Civilization.Fire, 1000, Subtype.MachineEater)
        {
            Abilities.Add(new SpeedAttackerAbility());
        }
    }
}
