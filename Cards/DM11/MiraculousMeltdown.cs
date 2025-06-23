using ContinuousEffects;
using Interfaces;
using OneShotEffects;

namespace Cards.DM11;

public sealed class MiraculousMeltdown : Spell
{
    public MiraculousMeltdown() : base("Miraculous Meltdown", 6, Civilization.Darkness, Civilization.Fire)
    {
        AddStaticAbilities(new MiraculousMeltdownContinuousEffect());
        AddSpellAbilities(new MiraculousMeltdownOneShotEffect());
    }
}
