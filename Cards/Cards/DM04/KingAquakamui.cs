using Common;
using Common.Choices;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM04
{
    class KingAquakamui : Creature
    {
        public KingAquakamui() : base("King Aquakamui", 7, 5000, Subtype.Leviathan, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new KingAquakamuiOneShotEffect()), new KingAquakamuiStaticAbility());
        }
    }

    class KingAquakamuiOneShotEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var player = game.GetPlayer(source.Owner);
            if (player.Choose(new YesNoChoice(player.Id, ToString()), game).Decision)
            {
                game.Move(ZoneType.Graveyard, ZoneType.Hand, player.Graveyard.Cards.Where(x => x.Subtypes.Contains(Subtype.AngelCommand) || x.Subtypes.Contains(Subtype.DemonCommand)).ToArray());
            }
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new KingAquakamuiOneShotEffect();
        }

        public override string ToString()
        {
            return "You may return all Angel Commands and all Demon Commands from your graveyard to your hand.";
        }
    }

    class KingAquakamuiStaticAbility : StaticAbility
    {
        public KingAquakamuiStaticAbility() : base(new KingAquakamuiContinuousEffect())
        {
        }
    }

    class KingAquakamuiContinuousEffect : PowerModifyingEffect
    {
        public KingAquakamuiContinuousEffect(KingAquakamuiContinuousEffect effect) : base(effect)
        {
        }

        public KingAquakamuiContinuousEffect() : base(2000, new CardFilters.BattleZoneSubtypeCreatureFilter(Subtype.AngelCommand, Subtype.DemonCommand), new Durations.Indefinite())
        {
        }

        public override ContinuousEffect Copy()
        {
            return new KingAquakamuiContinuousEffect(this);
        }

        public override string ToString()
        {
            return "You may return all Angel Commands and all Demon Commands from your graveyard to your hand.";
        }
    }
}
