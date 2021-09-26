using System;

namespace DuelMastersModels.Cards
{
    public abstract class Spell : Card
    {
        protected Spell(Guid owner, int cost, Civilization civilization) : base(owner, cost, civilization) { }

        protected Spell(Spell spell) : base(spell) { }
    }
}
