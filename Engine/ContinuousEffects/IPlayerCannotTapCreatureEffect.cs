namespace Engine.ContinuousEffects
{
    public interface IPlayerCannotTapCreatureEffect : IContinuousEffect
    {
        bool PlayerCannotTapCreature(Player player, Creature creature, IGame game);
    }
}
