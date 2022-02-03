using Cards.StaticAbilities;

namespace Cards.Cards.DM05
{
    public class RikabuTheDismantler : Creature
    {
        public RikabuTheDismantler() : base("Rikabu, the Dismantler", 3, Common.Civilization.Fire, 1000, Common.Subtype.MachineEater)
        {
            Abilities.Add(new SpeedAttackerAbility());
        }
    }
}
