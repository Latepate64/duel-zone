using Cards.StaticAbilities;

namespace Cards.Cards.DM05
{
    public class TwinCannonSkyterror : Creature
    {
        public TwinCannonSkyterror() : base("Twin-Cannon Skyterror", 7, Common.Civilization.Fire, 7000, Common.Subtype.ArmoredWyvern)
        {
            Abilities.Add(new SpeedAttackerAbility());
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
