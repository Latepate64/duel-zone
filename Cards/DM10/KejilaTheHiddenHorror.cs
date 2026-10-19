using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

sealed class KejilaTheHiddenHorror : SilentSkillCreature
{
    public KejilaTheHiddenHorror() : base("Kejila, the Hidden Horror", 6, 6000,
        Race.PandorasBox, Civilization.Darkness)
    {
        AddSilentSkillAbility(
            new ThisCreatureBreaksOpponentsShieldsEffect(2));
    }
}
