using Engine;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect : ContinuousEffect, ICannotUseCardEffect
    {
        public YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect()
        {
        }

        public YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect(YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect effect) : base(effect)
        {
        }

        public bool Applies(ICard card, IGame game)
        {
            // If player cast no spells during the turn, the creature cannot be summoned.
            return card == Source && !game.CurrentTurn.GameEvents.OfType<SpellCastEvent>().Any(x => x.Player == Applier);
        }

        public override IContinuousEffect Copy()
        {
            return new YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect(this);
        }

        public override string ToString()
        {
            return "You can summon this creature only if you have cast a spell this turn.";
        }
    }
}
