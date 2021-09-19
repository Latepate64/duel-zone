using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.StaticAbilities;
using DuelMastersModels.Abilities.TriggeredAbilities;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.Choices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DuelMastersModels.Zones;

namespace DuelMastersModels.Managers
{
    public class AbilityManager
    {
        #region Public
        public bool IsAbilityBeingResolved => _abilityBeingResolved != null;

        public bool IsAbilityBeingResolvedSpellAbility => _abilityBeingResolved is SpellAbility;

        public void TriggerWhenYouPutThisCreatureIntoTheBattleZoneAbilities(Creature creature)
        {
            TriggerTriggerAbilities<WhenYouPutThisCreatureIntoTheBattleZone>(creature);
        }

        public void TriggerWheneverAnotherCreatureIsPutIntoTheBattleZoneAbilities(IEnumerable<Creature> creatures)
        {
            TriggerTriggerAbilities<WheneverAnotherCreatureIsPutIntoTheBattleZone>(creatures);
        }

        public void TriggerWheneverAPlayerCastsASpellAbilities(IEnumerable<Creature> creatures)
        {
            TriggerTriggerAbilities<WheneverAPlayerCastsASpell>(creatures);
        }

        public ICollection<ContinuousEffect> GetContinuousEffectsGeneratedByCard(Card card, IPlayer player, BattleZone battleZone)
        {
            List<ContinuousEffect> continuousEffects = new List<ContinuousEffect>();
            foreach (StaticAbility staticAbility in GetStaticAbilities().Where(a => a.Source == card))
            {
                continuousEffects.AddRange(player.GetContinuousEffectsGeneratedByStaticAbility(card, staticAbility, battleZone));
            }
            return continuousEffects;
        }

        public PlayerActionWithEndInformation ContinueResolution(Duel duel)
        {
            return _abilityBeingResolved.ContinueResolution(duel);
        }

        public void SetAbilityBeingResolved(NonStaticAbility ability)
        {
            _abilityBeingResolved = ability;
        }

        public void StartResolvingSpellAbility(Spell spell)
        {
            //TODO: spell may have more than one spell ability.
            SpellAbility spellAbility = GetSpellAbilities().First(a => a.Source == spell);
            SetAbilityBeingResolved(spellAbility);
        }

        public int GetSpellAbilityCount(Spell spell)
        {
            return GetSpellAbilities().Count(a => a.Source == spell);
        }

        public void RemovePendingAbility(NonStaticAbility ability)
        {
            _ = _pendingAbilities.Remove(ability);
        }

        public SelectAbilityToResolve TryGetSelectAbilityToResolve(IPlayer player)
        {
            List<NonStaticAbility> pendingAbilities = GetPendingAbilitiesForPlayer(player);
            return pendingAbilities.Count > 0 ? new SelectAbilityToResolve(player, pendingAbilities) : null;
        }
        #endregion Public

        #region Private
        /// <summary>
        /// An ability can be a characteristic an card has that lets it affect the game. A card's abilities are defined by its rules text or by the effect that created it.
        /// </summary>
        private readonly Collection<Ability> _abilities = new Collection<Ability>();

        /// <summary>
        /// Non-static abilities that are waiting to be resolved.
        /// </summary>
        private readonly Collection<NonStaticAbility> _pendingAbilities = new Collection<NonStaticAbility>();

        /// <summary>
        /// A non-static ability that is currently being resolved.
        /// </summary>
        private NonStaticAbility _abilityBeingResolved;

        private Collection<TriggeredAbility> GetTriggerAbilities()
        {
            return new Collection<TriggeredAbility>(_abilities.Where(a => a is TriggeredAbility).Cast<TriggeredAbility>().ToList());
        }

        private ReadOnlyCollection<TriggeredAbility> GetTriggerAbilities<T>(Card card)
        {
            return new ReadOnlyCollection<TriggeredAbility>(GetTriggerAbilities().Where(ability => ability.Source == card && ability.TriggerCondition is T).ToList());
        }

        /// <summary>
        /// Once an ability has triggered, its controller puts it on the stack as an object that’s not a card the next time a player would receive priority.
        /// </summary>
        /// <param name="ability"></param>
        /// <param name="controller"></param>
        /// <param name="source"></param>
        private void TriggerTriggeredAbility(TriggeredAbility ability, IPlayer controller, Card source)
        {
            _pendingAbilities.Add(ability.CreatePendingTriggeredAbility(controller, source));
        }

        private void TriggerTriggerAbilities<T>(Creature card)
        {
            foreach (TriggeredAbility ability in GetTriggerAbilities<T>(card))
            {
                TriggerTriggeredAbility(ability, ability.Controller, card);
            }
        }

        private void TriggerTriggerAbilities<T>(IEnumerable<Creature> creatures)
        {
            foreach (Creature creature in creatures)
            {
                TriggerTriggerAbilities<T>(creature);
            }
        }

        private List<StaticAbility> GetStaticAbilities()
        {
            return new List<StaticAbility>(_abilities.Where(a => a is StaticAbility).Cast<StaticAbility>());
        }

        private List<SpellAbility> GetSpellAbilities()
        {
            return new List<SpellAbility>(_abilities.Where(a => a is SpellAbility).Cast<SpellAbility>());
        }

        /// <summary>
        /// Non-static abilities controlled by a player that are waiting to be resolved.
        /// </summary>
        private List<NonStaticAbility> GetPendingAbilitiesForPlayer(IPlayer player)
        {
            return new List<NonStaticAbility>(_pendingAbilities.Where(a => a.Controller == player));
        }
        #endregion Private
    }
}
