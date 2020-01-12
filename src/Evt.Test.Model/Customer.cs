using System;

namespace Evt.Test.Model
{
    public class Customer : EvtBaseModel
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
