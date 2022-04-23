using Engine.Abilities;
using System.Linq;

namespace Engine.GameEvents
{
    public class SpellCastEvent : GameEvent
    {
        public SpellCastEvent(IPlayer player, ICard spell)
        {
            Player = player;
            Spell = spell;
        }

        public IPlayer Player { get; }
        public ICard Spell { get; private set; }

        public override void Happen(IGame game)
        {
            // 601.2a To propose the casting of a spell, a player first moves that card from where it is to the stack.
            game.GetZone(Spell).Remove(Spell, game);
            Spell = Spell.Copy();
            Spell.Timestamp = game.GetTimestamp();
            game.SpellStack.Add(Spell, game);
            game.AddContinuousEffects(Spell, Spell.GetAbilities<IStaticAbility>().Where(x => x.FunctionZone == ZoneType.Anywhere).ToArray());
            Spell.KnownTo = game.Players.Select(x => x.Id).ToList();
            ResolveSpellAbilities(Spell, game);
            FinishCastingSpell(Spell, game);
        }

        public override string ToString()
        {
            return $"{Player} cast {Spell}.";
        }

        private static void ResolveSpellAbilities(ICard spell, IGame game)
        {
            foreach (var ability in spell.GetAbilities<SpellAbility>())
            {
                //ability.Source = spell.Id;
                //ability.Controller = spell.Owner;
                ability.Resolve(game);
            }
        }

        /// <summary>
        /// 608.2m As the final part of a spell’s resolution, the spell is put into its owner’s graveyard.
        /// </summary>
        /// <param name="spell"></param>
        /// <param name="game"></param>
        private void FinishCastingSpell(ICard spell, IGame game)
        {
            game.ProcessEvents(new CardMovedEvent(Player, ZoneType.SpellStack, ZoneType.Graveyard, spell.Id, false, null));
        }
    }
}
