using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.StaticAbilities;
using DuelMastersModels.Factories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Spell is a card type.
    /// </summary>
    public class Spell : Card, ISpell
    {
        /// <summary>
        /// Creates a spell.
        /// </summary>
        public Spell(string name, string set, string id, Collection<string> civilizations, string rarity, int cost, string text, string flavor, string illustrator) : base(name, set, id, cost, text, flavor, illustrator, civilizations, rarity)
        {
        }

        internal ReadOnlyCollection<Ability> TryParseSpellAbilities(Player owner)
        {
            AbilityCollection abilities = new AbilityCollection();
            if (!string.IsNullOrEmpty(Text))
            {
                IEnumerable<string> textParts = Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Where(t => !(t.StartsWith("(", StringComparison.CurrentCulture) && t.EndsWith(")", StringComparison.CurrentCulture)));
                foreach (string textPart in textParts)
                {
                    StaticAbility staticAbility = StaticAbilityFactory.ParseStaticAbilityForSpell(textPart, this);
                    if (staticAbility != null)
                    {
                        abilities.Add(staticAbility);
                    }
                    else
                    {
                        abilities.Add(new SpellAbility(EffectFactory.ParseOneShotEffect(textPart), owner, this));
                    }
                }
            }
            return abilities;
        }
    }
}
