using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM01
{
    class Tropico : Creature
    {
        public Tropico() : base("Tropico", 5, 3000, Race.CyberLord, Civilization.Water)
        {
            AddStaticAbilities(new TropicoEffect());
        }
    }

    class TropicoEffect : ContinuousEffect, IUnblockableEffect
    {
        public TropicoEffect() : base()
        {
        }

        public bool CannotBeBlocked(ICard attacker, ICard blocker, IAttackable targetOfAttack, IGame game)
        {
            return attacker == Ability.SourceCard && game.BattleZone.GetCreatures(Controller.Id).Count(x => x != Ability.SourceCard) >= 2;
        }

        public override IContinuousEffect Copy()
        {
            return new TropicoEffect();
        }

        public override string ToString()
        {
            return "This creature can't be blocked while you have at least 2 other creatures in the battle zone.";
        }
    }
}
