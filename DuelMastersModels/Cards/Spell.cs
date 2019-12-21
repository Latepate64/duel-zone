using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.Static;
using DuelMastersModels.Effects.OneShotEffects;
using DuelMastersModels.Factories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    public class Spell : Card
    {
        public Collection<SpellAbility> SpellAbilities => new Collection<SpellAbility>(Abilities.Where(a => a is SpellAbility).Cast<SpellAbility>().ToList());

        public override Card DeepCopy
        {
            get
            {
                Spell spell = new Spell()
                {
                    Cost = Cost,
                    Flavor = Flavor,
                    GameId = GameId,
                    Id = Id,
                    Illustrator = Illustrator,
                    Name = Name,
                    Rarity = Rarity,
                    Set = Set,
                    Tapped = Tapped,
                    Text = Text
                };
                foreach (Civilization civilization in Civilizations)
                {
                    spell.Civilizations.Add(civilization);
                }
                return spell;
            }
        }

        public Spell() : base()
        {
        }

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
                        Collection<OneShotEffect> effects = EffectFactory.ParseOneShotEffect(textPart);
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
