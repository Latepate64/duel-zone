using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM12
{
    class UlarusPunishmentElemental : Creature
    {
        public UlarusPunishmentElemental() : base("Ularus, Punishment Elemental", 5, 4500, Race.AngelCommand, Civilization.Light)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new UlarusEffect());
        }
    }

    class UlarusEffect : OneShotEffect
    {
        public UlarusEffect()
        {
        }

        public UlarusEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var maximum = game.BattleZone.GetCreatures(Applier.Id).Count();
            var shields = Applier.ShieldZone.Cards.Union(Applier.Opponent.ShieldZone.Cards);
            var chosen = Applier.ChooseCards(shields, 0, maximum, ToString()).ToList();
            chosen.ForEach(x => x.FaceDown = false);
        }

        public override IOneShotEffect Copy()
        {
            return new UlarusEffect(this);
        }

        public override string ToString()
        {
            return "For each creature you have in the battle zone, you may choose a shield and turn it face up.";
        }
    }
}
