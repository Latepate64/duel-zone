using DuelMastersModels.Abilities.Static;
using DuelMastersModels.Abilities.Trigger;
using DuelMastersModels.Effects.OneShotEffects;
using DuelMastersModels.Factories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    public class Creature : Card
    {
        /// <summary>
        /// The base power of creature. Use Duel's method GetPower(creature) in order to get the actual power of a creature.
        /// </summary>
        public int Power { get; private set; }
        public Collection<string> Races { get; } = new Collection<string>();

        private bool _summoningSickness = true;
        public bool SummoningSickness
        {
            get => _summoningSickness;
            set
            {
                if (value != _summoningSickness)
                {
                    _summoningSickness = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Creature() : base()
        {
        }

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
            Races = races;

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
            if (triggerCondition != null)
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
