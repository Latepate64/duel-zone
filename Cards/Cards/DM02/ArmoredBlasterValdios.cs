using Cards.ContinuousEffects;
using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM02
{
    class ArmoredBlasterValdios : EvolutionCreature
    {
        public ArmoredBlasterValdios() : base("Armored Blaster Valdios", 4, 6000, Subtype.Human, Civilization.Fire)
        {
            AddStaticAbilities(new ArmoredBlasterValdiosEffect());
            AddDoubleBreakerAbility();
        }
    }

    class ArmoredBlasterValdiosEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public ArmoredBlasterValdiosEffect() : base() { }

        public override IContinuousEffect Copy()
        {
            return new ArmoredBlasterValdiosEffect();
        }

        public void ModifyPower(IGame game)
        {
            game.BattleZone.GetCreatures(GetController(game).Id).Where(x => !IsSourceOfAbility(x, game) && x.HasSubtype(Subtype.Human)).ToList().ForEach(x => x.Power += 1000);
        }

        public override string ToString()
        {
            return "Each of your other Humans in the battle zone gets +1000 power.";
        }
    }
}