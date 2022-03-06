using Cards.StaticAbilities;

namespace Cards.Cards.DM05
{
    class RikabuTheDismantler : Creature
    {
        public RikabuTheDismantler() : base("Rikabu, the Dismantler", 3, 1000, Common.Subtype.MachineEater, Common.Civilization.Fire)
        {
            Abilities.Add(new SpeedAttackerAbility());
        }
    }
}
