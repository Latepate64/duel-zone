using System;

namespace Engine.Abilities
{
    public interface IAbility
    {
        Guid Id { get; }
        Guid Owner { get; set; }
        Guid Source { get; set; }

        IAbility Copy();
        string ToString();
    }
}