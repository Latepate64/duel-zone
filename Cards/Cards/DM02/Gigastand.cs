using Cards.ContinuousEffects;
using Cards.TriggeredAbilities;
using Common;
using Common.Choices;
using Common.GameEvents;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM02
{
    class Gigastand : Creature
    {
        public Gigastand() : base("Gigastand", 4, 3000, Subtype.Chimera, Civilization.Darkness)
        {
            AddAbilities(new StaticAbility(new GigastandEffect()));
        }
    }

    class GigastandEffect : DestructionReplacementEffect
    {
        public GigastandEffect() : base()
        {
        }

        public GigastandEffect(ReplacementEffect effect) : base(effect)
        {
        }

        public override bool Apply(Game game, Engine.Player player)
        {
            if (player.Choose(new YesNoChoice(player.Id, ToString()), game).Decision)
            {
                game.Move(ZoneType.BattleZone, ZoneType.Hand, GetAffectedCards(game).ToArray());
                new ReflexiveTriggeredAbility(new OneShotEffects.DiscardEffect(new CardFilters.OwnersHandCardFilter(), 1, 1, true)).Resolve(game);
                return true;
            }
            return false;
        }

        public override ContinuousEffect Copy()
        {
            return new GigastandEffect(this);
        }

        public override string ToString()
        {
            return base.ToString() +  "you may return it to your hand instead. If you do, discard a card from your hand.";
        }
    }
}
