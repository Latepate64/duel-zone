namespace Cards.Cards.DM05
{
    class TwinCannonSkyterror : Creature
    {
        public TwinCannonSkyterror() : base("Twin-Cannon Skyterror", 7, 7000, Engine.Subtype.ArmoredWyvern, Engine.Civilization.Fire)
        {
            AddSpeedAttackerAbility();
            AddDoubleBreakerAbility();
        }
    }
}
