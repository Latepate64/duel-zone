using Engine;
using Interfaces;

namespace Cards.DM05;

public sealed class MiracleQuest : Spell
{
    public MiracleQuest() : base("Miracle Quest", 3, Civilization.Water)
    {
        AddSpellAbilities(new MiracleQuestEffect());
    }
}
