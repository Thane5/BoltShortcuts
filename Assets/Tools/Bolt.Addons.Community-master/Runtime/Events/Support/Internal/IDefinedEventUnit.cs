﻿using System.Collections.Generic;

namespace Bolt.Addons.Community.DefinedEvents.Support.Internal
{
    interface IDefinedEventUnit
    {
        List<ValueOutput> outputPorts { get; }
    }
}