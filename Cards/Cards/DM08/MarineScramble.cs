using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM08
{
    class MarineScramble : Spell
    {
        public MarineScramble() : base("Marine Scramble", 7, Civilization.Water)
        {
            AddSpellAbilities(new MarineScrambleEffect());
        }
    }

    class MarineScrambleEffect : OneShotEffect
    {
        public MarineScrambleEffect() : base()
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new YourCreaturesCannotBeBlockedThisTurnEffect());
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new MarineScrambleEffect();
        }

        public override string ToString()
        {
            return "Your creatures in the battle zone can't be blocked this turn.";
        }
    }

    class YourCreaturesCannotBeBlockedThisTurnEffect : ContinuousEffects.UntilEndOfTurnEffect, IUnblockableEffect
    {
        public YourCreaturesCannotBeBlockedThisTurnEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter())
        {
        }

        public bool Applies(Engine.ICard blocker, IGame game)
        {
            return true;
        }

        public override IContinuousEffect Copy()
        {
            return new YourCreaturesCannotBeBlockedThisTurnEffect();
        }

        public override string ToString()
        {
            return "Your creatures in the battle zone can't be blocked this turn.";
        }
    }
}
