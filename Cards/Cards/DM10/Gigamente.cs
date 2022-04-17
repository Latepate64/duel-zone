namespace Cards.Cards.DM10
{
    class Gigamente : SilentSkillCreature
    {
        public Gigamente() : base("Gigamente", 4, 3000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddSilentSkillAbility(new OneShotEffects.ReturnCreatureFromYourGraveyardToYourHandEffect());
        }
    }
}
