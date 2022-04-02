using Common;

namespace Cards.Cards.DM10
{
    class MezgerCommandoLeader : Creature
    {
        public MezgerCommandoLeader() : base("Mezger, Commando Leader", 4, 2000, Subtype.Human, Civilization.Fire)
        {
            AddSpeedAttackerAbility();
        }
    }
}
