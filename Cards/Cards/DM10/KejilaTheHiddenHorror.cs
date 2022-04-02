using Common;

namespace Cards.Cards.DM10
{
    class KejilaTheHiddenHorror : SilentSkillCreature
    {
        public KejilaTheHiddenHorror() : base("Kejila, the Hidden Horror", 6, 6000, Subtype.PandorasBox, Civilization.Darkness)
        {
            AddSilentSkillAbility(new OneShotEffects.ThisCreatureBreaksOpponentsShieldsEffect(2));
        }
    }
}
