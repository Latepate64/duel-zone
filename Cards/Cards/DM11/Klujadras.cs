using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM11
{
    class Klujadras : WaveStrikerCreature
    {
        public Klujadras() : base("Klujadras", 7, 4000, Race.SeaHacker, Civilization.Water)
        {
            AddWaveStrikerAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new KlujadrasEffect()));
        }
    }

    class KlujadrasEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            foreach (var player in game.Players)
            {
                player.DrawCards(game.BattleZone.GetCreatures(player.Id).Count(x => x.GetAbilities<StaticAbilities.WaveStrikerAbility>().Any()), game, source);
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
