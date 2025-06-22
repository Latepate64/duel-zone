using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using Interfaces;

namespace GameEvents;

public sealed class SpellCastEvent(Player player, ICard spell) : GameEvent
{
    public Player Player { get; } = player;
    public ICard Spell { get; private set; } = spell;

    public override void Happen(IGame game)
    {
        // 601.2a To propose the casting of a spell, a player first moves that card from where it is to the stack.
        // game.GetZone(Spell).Remove(Spell);
        Spell = Spell.Copy();
        // Spell.SetTimestamp(game.GetTimestamp());
        // game.SpellStack.Add(Spell);
        game.ContinuousEffects.Add(Spell, [.. Spell.GetAbilities<IStaticAbility>().Where(
            x => x.FunctionZone == ZoneType.Anywhere)]);
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