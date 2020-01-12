using System;

namespace Evt.Test.Model
{
    public class EvtBaseModel
    {
        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
