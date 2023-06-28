using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM04
{
    class KingAquakamui : Creature
    {
        public KingAquakamui() : base("King Aquakamui", 7, 5000, Race.Leviathan, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new KingAquakamuiOneShotEffect());
            AddStaticAbilities(new KingAquakamuiContinuousEffect());
        }
    }

    class KingAquakamuiOneShotEffect : OneShotEffect
    {
        public override void Apply()
        {
            if (Applier.ChooseToTakeAction(ToString()))
            {
                Game.Move(Ability, ZoneType.Graveyard, ZoneType.Hand, Applier.Graveyard.Cards.Where(x => x.HasRace(Race.AngelCommand) || x.HasRace(Race.DemonCommand)).ToArray());
            }
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

    class KingAquakamuiContinuousEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public KingAquakamuiContinuousEffect(KingAquakamuiContinuousEffect effect) : base(effect)
        {
        }

        public KingAquakamuiContinuousEffect() : base()
        {
        }

        public override ContinuousEffect Copy()
        {
            return new KingAquakamuiContinuousEffect(this);
        }

        public override string ToString()
        {
            return "Angel Commands and Demon Commands in the battle zone each get +2000 power.";
        }

        public void ModifyPower(IGame game)
        {
            game.BattleZone.Creatures.Where(x => x.HasRace(Race.AngelCommand) || x.HasRace(Race.DemonCommand)).ToList().ForEach(x => x.Power += 2000);
        }
    }
}
