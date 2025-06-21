using ContinuousEffects;

namespace Cards.DM10
{
    class MezgerCommandoLeader : Engine.Creature
    {
        public MezgerCommandoLeader() : base("Mezger, Commando Leader", 4, 2000, Interfaces.Race.Human, Interfaces.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
        }
    }
}
