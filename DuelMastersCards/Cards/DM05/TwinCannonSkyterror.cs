using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM05
{
    public class TwinCannonSkyterror : Creature
    {
        public TwinCannonSkyterror() : base("Twin-Cannon Skyterror", 7, Civilization.Fire, 7000, Subtype.ArmoredWyvern)
        {
            Abilities.Add(new SpeedAttackerAbility());
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
