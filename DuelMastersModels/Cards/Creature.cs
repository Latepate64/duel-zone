using DuelMastersModels.Abilities.Static;
using DuelMastersModels.Abilities.Trigger;
using DuelMastersModels.Effects.OneShotEffects;
using DuelMastersModels.Factories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Creature is a card type.
    /// </summary>
    public class Creature : Card
    {
        #region Properties
        /// <summary>
        /// The base power of creature. Use Duel's method GetPower(creature) in order to get the actual power of a creature.
        /// </summary>
        public int Power { get; private set; }

        /// <summary>
        /// Race is a characteristic of a creature.
        /// </summary>
        public ReadOnlyCollection<string> Races => new ReadOnlyCollection<string>(_races);

        /// <summary>
        /// Summoning sickness limits when a creature is able to attack.
        /// </summary>
        public bool SummoningSickness { get; set; } = true;
        #endregion Properties

        private readonly ReadOnlyCollection<string> _races;

        /// <summary>
        /// Creates a creature.
        /// </summary>
        public Creature(string name, string set, string id, Collection<string> civilizations, string rarity, int cost, string text, string flavor, string illustrator, int gameId, string power, Collection<string> races, Player owner) : base(name, set, id, civilizations, rarity, cost, text, flavor, illustrator, gameId)
        {
            if (power == null)
            {
                throw new System.ArgumentNullException("power");
            }
            Power = int.Parse(power.Replace("+", "").Replace("-", ""), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            _races = new ReadOnlyCollection<string>(races);

            if (!string.IsNullOrEmpty(text))
            {
                IEnumerable<string> textParts = text.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries).Where(t => !(t.StartsWith("(", System.StringComparison.CurrentCulture) && t.EndsWith(")", System.StringComparison.CurrentCulture)));
                foreach (string textPart in textParts)
                {
                    StaticAbility staticAbility = StaticAbilityFactory.ParseStaticAbilityForCreature(textPart, this);
                    if (staticAbility != null)
                    {
                        Abilities.Add(staticAbility);
                    }
                    else
                    {
                        Abilities.Ability nonStaticAbility = ParseTriggerAbility(owner, textPart);
                        if (nonStaticAbility != null)
                        {
                            Abilities.Add(nonStaticAbility);
                        }
                    }
                }
            }
        }

        private Abilities.Ability ParseTriggerAbility(Player owner, string textPart)
        {
            TriggerConditionAndRemainingText triggerCondition = TriggerConditionFactory.ParseTriggerCondition(textPart);
            if (triggerCondition.TriggerCondition != null)
            {
                ReadOnlyOneShotEffectCollection effects = EffectFactory.ParseOneShotEffect(triggerCondition.RemainingText, owner);
                if (effects != null)
                {
                    return new TriggerAbility(triggerCondition.TriggerCondition, effects, owner, this);
                }
                else
                {
                    return ParseTriggerAbilityWithOneShotEffectForCreature(owner, triggerCondition);
                }
            }
            else
            {
                Duel.NotParsedAbilities.Add(textPart);
                return null;
            }
        }

        private Abilities.Ability ParseTriggerAbilityWithOneShotEffectForCreature(Player owner, TriggerConditionAndRemainingText triggerCondition)
        {
            OneShotEffectForCreature oneShotEffectForCreature = EffectFactory.ParseOneShotEffectForCreature(triggerCondition.RemainingText, this);
            if (oneShotEffectForCreature != null)
            {
                return new TriggerAbility(triggerCondition.TriggerCondition, new ReadOnlyOneShotEffectCollection(oneShotEffectForCreature), owner, this);
            }
            else
            {
                Duel.NotParsedAbilities.Add(triggerCondition.RemainingText);
                return null;
            }
        }
    }
}
