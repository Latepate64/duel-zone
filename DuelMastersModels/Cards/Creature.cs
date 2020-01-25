using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.TriggerAbilities;
using DuelMastersModels.Effects.OneShotEffects;
using DuelMastersModels.Exceptions;
using DuelMastersModels.Factories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Creature is a card type.
    /// </summary>
    public class Creature : Card, ICreature
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
        public bool SummoningSickness { get; internal set; } = true;
        #endregion Properties

        #region Fields
        private readonly ReadOnlyCollection<string> _races;

        private readonly ReadOnlyDictionary<string, Type> _creatureEffectDictionary = new ReadOnlyDictionary<string, Type>(new Dictionary<string, Type>
        {
            { "This creature gets $plusinteger power until the end of the turn.", typeof(ThisCreatureGetsXPowerUntilTheEndOfTheTurn) },
            { "This creature gets $plusinteger power until the end of the turn. (Do what the spell says before this creature gets the extra power.)", typeof(ThisCreatureGetsXPowerUntilTheEndOfTheTurn) },
        });
        #endregion Fields

        /// <summary>
        /// Creates a creature.
        /// </summary>
        public Creature(string name, string set, string id, Collection<string> civilizations, string rarity, int cost, string text, string flavor, string illustrator, string power, Collection<string> races) : base(name, set, id, cost, text, flavor, illustrator, civilizations, rarity)
        {
            if (power == null)
            {
                throw new ArgumentNullException(nameof(power));
            }
            Power = int.Parse(power.Replace("+", "").Replace("-", ""), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
            _races = new ReadOnlyCollection<string>(races);
        }

        /// <summary>
        /// Creates a creature.
        /// </summary>
        internal Creature(string name, string set, string id, ReadOnlyCivilizationCollection civilizations, Rarity rarity, int cost, string text, string flavor, string illustrator, int power, ReadOnlyCollection<string> races) : base(name, set, id, cost, text, flavor, illustrator, civilizations, rarity)
        {
            Power = power;
            _races = new ReadOnlyCollection<string>(races);
        }

        #region Methods
        internal ReadOnlyCollection<Ability> TryParseCreatureAbilities(Player owner)
        {
            AbilityCollection abilities = new AbilityCollection();
            if (!string.IsNullOrEmpty(Text))
            {
                IEnumerable<string> textParts = Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).Where(t => !(t.StartsWith("(", StringComparison.CurrentCulture) && t.EndsWith(")", StringComparison.CurrentCulture)));
                foreach (string textPart in textParts)
                {
                    Abilities.StaticAbilities.StaticAbility staticAbility = StaticAbilityFactory.ParseStaticAbilityForCreature(textPart, this);
                    if (staticAbility != null)
                    {
                        abilities.Add(staticAbility);
                    }
                    else
                    {
                        abilities.Add(ParseTriggerAbility(owner, textPart));
                    }
                }
            }
            return abilities;
        }

        private NonStaticAbility ParseTriggerAbility(Player owner, string textPart)
        {
            TriggerConditionAndRemainingText triggerCondition = TriggerConditionFactory.ParseTriggerCondition(textPart);
            if (triggerCondition.TriggerCondition != null)
            {
                ReadOnlyOneShotEffectCollection effects = EffectFactory.ParseOneShotEffect(triggerCondition.RemainingText);
                return effects != null
                    ? new TriggerAbility(triggerCondition.TriggerCondition, effects, owner, this)
                    : ParseTriggerAbilityWithOneShotEffectForCreature(owner, triggerCondition);
            }
            else
            {
                throw new ParseException(textPart);
            }
        }

        private NonStaticAbility ParseTriggerAbilityWithOneShotEffectForCreature(Player owner, TriggerConditionAndRemainingText triggerCondition)
        {
            OneShotEffectForCreature oneShotEffectForCreature = ParseOneShotEffectForCreature(triggerCondition.RemainingText);
            if (oneShotEffectForCreature != null)
            {
                return new TriggerAbility(triggerCondition.TriggerCondition, new ReadOnlyOneShotEffectCollection(oneShotEffectForCreature), owner, this);
            }
            else
            {
                throw new ParseException(triggerCondition.RemainingText);
            }
        }

        private OneShotEffectForCreature ParseOneShotEffectForCreature(string text)
        {
            ParsedTypesAndObjects parsedTypesAndObjects = AbilityTypeFactory.GetTypeFromDictionary(text, _creatureEffectDictionary);
            return parsedTypesAndObjects?.ParsedType != null && string.IsNullOrEmpty(parsedTypesAndObjects.ParsedType.RemainingText)
                ? Activator.CreateInstance(parsedTypesAndObjects.ParsedType.TypesParsed[0], AbilityTypeFactory.GetInstanceParameters(this, new Collection<object>(parsedTypesAndObjects.Objects.Values.ToList()))) as OneShotEffectForCreature
                : null;
        }
        #endregion Methods
    }
}
