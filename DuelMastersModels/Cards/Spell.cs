using DuelMastersModels.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Cards
{
    public abstract class Spell : Card
    {
        public ICollection<SpellAbility> SpellAbilities { get; private set; } = new List<SpellAbility>();

        protected Spell(Guid owner, int cost, Civilization civilization) : base(owner, cost, civilization) { }

        protected Spell(Spell spell) : base(spell)
        {
            SpellAbilities = spell.SpellAbilities.Select(x => x.Copy()).Cast<SpellAbility>().ToList();
        }
    }
}
