using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM06
{
    class ForbiddingTotem : Creature
    {
        public ForbiddingTotem() : base("Forbidding Totem", 5, 4000, Race.MysteryTotem, Civilization.Nature)
        {
            AddStaticAbilities(new ForbiddingTotemAbility());
        }
    }

    class ForbiddingTotemAbility : ContinuousEffect, ICannotAttackCreaturesEffect, ICannotAttackPlayersEffect
    {
        public ForbiddingTotemAbility()
        {
        }

        public ForbiddingTotemAbility(ForbiddingTotemAbility effect) : base(effect)
        {
        }

        public bool CannotAttackCreature(ICard attacker, ICard target, IGame game)
        {
            // Your opponent's attacking creatures can't attack creatures other than Mystery Totems if a Mystery Totem could be attacked this way.
            if (attacker.Id == game.GetOpponent(Controller).Id)
            {
                if (!target.HasRace(Race.MysteryTotem))
                {
                    return AttackableMysteryTotemExists(attacker, game);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool CannotAttackPlayers(ICard attacker, IGame game)
        {
            return attacker.Id == game.GetOpponent(Controller).Id && AttackableMysteryTotemExists(attacker, game);
        }

        public override IContinuousEffect Copy()
        {
            return new ForbiddingTotemAbility(this);
        }

        public override string ToString()
        {
            return "Your opponent's attacking creatures attack Mystery Totems if able.";
        }

        private bool AttackableMysteryTotemExists(ICard attacker, IGame game)
        {
            return game.BattleZone.GetCreatures(Controller.Id, Race.MysteryTotem).Any(x => attacker.CanAttackCreature(x, game));
        }
    }
}
