using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM11
{
    class MiraculousSnare : Spell
    {
        public MiraculousSnare() : base("Miraculous Snare", 3, Civilization.Light, Civilization.Water)
        {
            AddSpellAbilities(new MiraculousSnareEffect());
        }
    }

    class MiraculousSnareEffect : OneShotEffects.CardMovingChoiceEffect
    {
        public MiraculousSnareEffect() : base(1, 1, true, ZoneType.BattleZone, ZoneType.ShieldZone)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new MiraculousSnareEffect();
        }

        public override string ToString()
        {
            return "Choose a non-evolution creature in the battle zone and add it to its owner's shields face down.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByAnyone(game, Applier).Where(x => !x.IsEvolutionCreature);
        }
    }
}
