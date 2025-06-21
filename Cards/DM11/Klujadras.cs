using TriggeredAbilities;
using ContinuousEffects;
using Engine.Abilities;
using System.Linq;
using Interfaces;

namespace Cards.DM11
{
    class Klujadras : WaveStrikerCreature
    {
        public Klujadras() : base("Klujadras", 7, 4000, Race.SeaHacker, Civilization.Water)
        {
            AddWaveStrikerAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new KlujadrasEffect()));
        }
    }

    class KlujadrasEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            foreach (var player in game.Players)
            {
                player.DrawCards(game.BattleZone.GetCreatures(player.Id).Count(
                    x => x.GetAbilities<StaticAbility>().SelectMany(
                        x => x.ContinuousEffects).OfType<WaveStrikerEffect>().Any()), game, Ability);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new KlujadrasEffect();
        }

        public override string ToString()
        {
            return "Each player draws a card for each of his creatures in the battle zone that has \"wave striker.\"";
        }
    }
}
