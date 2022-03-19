using System;
using System.Collections.Generic;

namespace Common.Choices
{
    public interface IGuidDecision
    {
        List<Guid> Decision { get; set; }
    }
}