using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM10
{
    class MezgerCommandoLeader : Engine.Creature
    {
        public MezgerCommandoLeader() : base("Mezger, Commando Leader", 4, 2000, Engine.Race.Human, Engine.Civilization.Fire)
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
        }
    }
}
