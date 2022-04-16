namespace Cards.Cards.DM10
{
    class MinelordSkyterror : SilentSkillCreature
    {
        public MinelordSkyterror() : base("Minelord Skyterror", 4, 3000, Engine.Race.ArmoredWyvern, Engine.Civilization.Fire)
        {
            AddSilentSkillAbility(new OneShotEffects.DestroyMaxPowerAreaOfEffect(3000));
        }
    }
}
