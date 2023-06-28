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
        public override void Apply()
        {
            foreach (var player in Game.Players)
            {
                player.DrawCards(Game.BattleZone.GetCreatures(player).Count(x => x.GetAbilities<StaticAbilities.WaveStrikerAbility>().Any()), Ability);
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
