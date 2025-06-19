using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class RikabuTheDismantler : Engine.Creature
    {
        public RikabuTheDismantler() : base("Rikabu, the Dismantler", 3, 1000, Engine.Race.MachineEater, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
        }
    }
}
