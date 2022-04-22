namespace Cards.Cards.DM10
{
    class KejilaTheHiddenHorror : SilentSkillCreature
    {
        public KejilaTheHiddenHorror() : base("Kejila, the Hidden Horror", 6, 6000, Engine.Race.PandorasBox, Engine.Civilization.Darkness)
        {
            AddSilentSkillAbility(new OneShotEffects.ThisCreatureBreaksOpponentsTwoShieldsEffect());
        }
    }
}
