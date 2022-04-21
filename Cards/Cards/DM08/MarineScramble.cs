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

        public MarineScrambleEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            game.AddContinuousEffects(Source, new YourCreaturesCannotBeBlockedThisTurnEffect());
        }

        public override IOneShotEffect Copy()
        {
            return new MarineScrambleEffect(this);
        }

        public override string ToString()
        {
            return "Your creatures in the battle zone can't be blocked this turn.";
        }
    }

    class YourCreaturesCannotBeBlockedThisTurnEffect : ContinuousEffects.UntilEndOfTurnEffect, IUnblockableEffect
    {
        public YourCreaturesCannotBeBlockedThisTurnEffect() : base()
        {
        }

        public bool CannotBeBlocked(ICard attacker, ICard blocker, IAttackable targetOfAttack, IGame game)
        {
            return game.BattleZone.GetCreatures(Controller.Id).Contains(attacker);
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
