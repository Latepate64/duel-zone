using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.Static;
using DuelMastersModels.Effects.OneShotEffects;
using DuelMastersModels.Factories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Spell is a card type.
    /// </summary>
    public class Spell : Card
    {
        internal ReadOnlySpellAbilityCollection SpellAbilities => new ReadOnlySpellAbilityCollection(Abilities.Where(a => a is SpellAbility).Cast<SpellAbility>());

        /// <summary>
        /// Creates a spell.
        /// </summary>
        public Spell(string name, string set, string id, Collection<string> civilizations, string rarity, int cost, string text, string flavor, string illustrator, int gameId, Player owner) : base(name, set, id, civilizations, rarity, cost, text, flavor, illustrator, gameId)
        {
            if (!string.IsNullOrEmpty(text))
            {
                IEnumerable<string> textParts = text.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries).Where(t => !(t.StartsWith("(", System.StringComparison.CurrentCulture) && t.EndsWith(")", System.StringComparison.CurrentCulture)));
                foreach (string textPart in textParts)
                {
                    StaticAbility staticAbility = StaticAbilityFactory.ParseStaticAbilityForSpell(textPart, this);
                    if (staticAbility != null)
                    {
                        Abilities.Add(staticAbility);
                    }
                    else
                    {
                        ReadOnlyOneShotEffectCollection effects = EffectFactory.ParseOneShotEffect(textPart, owner);
                        if (effects != null)
                        {
                            Abilities.Add(new SpellAbility(effects, owner, this));
                        }
                        else
                        {
                            Duel.NotParsedAbilities.Add(textPart);
                        }
                    }
                }
            }
        }
    }
}
