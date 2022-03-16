﻿using Engine.Durations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.ContinuousEffects
{
    /// <summary>
    /// 611.1. A continuous effect modifies characteristics of objects, modifies control of objects, or affects players or the rules of the game, for a fixed or indefinite period.
    /// </summary>
    public abstract class ContinuousEffect : IDisposable, ITimestampable
    {
        /// <summary>
        /// 611.2a A continuous effect generated by the resolution of a spell or ability lasts as long as stated by the spell or ability creating it (such as “until end of turn”). If no duration is stated, it lasts until the end of the game.
        /// </summary>
        public Duration Duration { get; set; }

        /// <summary>
        /// Filter that can be applied to find cards affected by the effect.
        /// </summary>
        public CardFilter Filter { get; set; }

        public Guid SourceAbility { get; internal set; }

        public int Timestamp { get; internal set; }

        private readonly List<Condition> _conditions = new();

        /// <summary>
        /// This constructor should only be used for continuous effects that are generated by a static ability of a card which only affects the card itself indefinitely.
        /// </summary>
        protected ContinuousEffect(params Condition[] conditions) : this(new TargetFilter(), new Indefinite(), conditions)
        {
        }

        protected ContinuousEffect(CardFilter filter, params Condition[] conditions) : this(filter, new Indefinite(), conditions)
        {
        }

        protected ContinuousEffect(CardFilter filter, Duration duration, params Condition[] conditions)
        {
            _conditions.AddRange(conditions);
            Duration = duration;
            Filter = filter;
        }

        protected ContinuousEffect(ContinuousEffect effect)
        {
            _conditions = effect._conditions.ToList(); //TODO: Implement copy?
            Duration = effect.Duration.Copy();
            Filter = effect.Filter?.Copy();
            SourceAbility = effect.SourceAbility;
        }

        public abstract ContinuousEffect Copy();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Duration.Dispose();
                Duration = null;
                Filter.Dispose();
                Filter = null;
                SourceAbility = Guid.Empty;
            }
        }

        public override abstract string ToString();

        protected string GetDurationAsText()
        {
            if (Duration is Indefinite)
            {
                return "";
            }
            else
            {
                return Duration.ToString();
            }
        }

        internal void SetupConditionFilters(System.Guid id)
        {
            _conditions.Select(x => x.Filter).ToList().ForEach(x => x.Target = id);
        }

        internal bool ConditionsApply(Game game)
        {
            var source = game.GetAbility(SourceAbility);
            if (source != null)
            {
                var player = game.GetPlayer(source.Owner);
                if (player != null && _conditions.All(x => x.Applies(game, player.Id)))
                {
                    return true;
                }
            }
            return false;
        }

        protected string ToStringBase()
        {
            if (_conditions.Any())
            {
                return string.Join(" and ", _conditions) + " ,";
            }
            else
            {
                return string.Empty;
            }
        }

        protected IEnumerable<Card> GetAffectedCards(Game game)
        {
            return game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(game.GetAbility(SourceAbility).Owner)));
        }
    }
}
