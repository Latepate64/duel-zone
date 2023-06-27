using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Collections.Generic;

namespace Cards.Cards.DM10
{
    class LegacyShell : Creature
    {
        public LegacyShell() : base("Legacy Shell", 5, 4000, Race.ColonyBeetle, Civilization.Nature)
        {
            AddStaticAbilities(new LegacyShellEffect());
        }
    }

    class LegacyShellEffect : AbilityAddingEffect
    {
        public LegacyShellEffect() : base(new StaticAbilities.PowerAttackerAbility(3000))
        {
        }

        public override IContinuousEffect Copy()
        {
            return new LegacyShellEffect();
        }

        public override string ToString()
        {
            return "Each of your light creatures and fire creatures has \"power attacker +3000.\"";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game)
        {
            return game.BattleZone.GetCreatures(Applier.Id, Civilization.Light, Civilization.Fire);
        }
    }
}
