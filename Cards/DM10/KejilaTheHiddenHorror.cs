namespace Cards.DM10
{
    sealed class KejilaTheHiddenHorror : SilentSkillCreature
    {
        public KejilaTheHiddenHorror() : base("Kejila, the Hidden Horror", 6, 6000, Interfaces.Race.PandorasBox, Interfaces.Civilization.Darkness)
        {
            AddSilentSkillAbility(new OneShotEffects.ThisCreatureBreaksOpponentsTwoShieldsEffect());
        }
    }
}
