using System.Linq;
using Abilities;
using Interfaces;

namespace Cards;

public class Spell : Card, ISpell
{
    protected Spell(string name, int manaCost, Civilization civilization) : base(false, [civilization], manaCost, name)
    {
    }

    protected Spell(string name, int manaCost, Civilization civilization1, Civilization civilization2) : base(false,
        [civilization1, civilization2], manaCost, name)
    {
    }

    public Spell(Spell spell) : base(spell)
    {
    }

    public override Spell Copy()
    {
        return new Spell(this);
    }

    /// <summary>
    /// Adds a spell ability for each one-shot effect provided.
    /// </summary>
    /// <param name="oneShotEffects"></param>
    protected void AddSpellAbilities(params IOneShotEffect[] oneShotEffects)
    {
        AddAbilities([.. oneShotEffects.Select(x => new SpellAbility(x))]);
    }
}