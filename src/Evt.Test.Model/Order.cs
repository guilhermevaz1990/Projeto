using System.ComponentModel.DataAnnotations.Schema;

namespace Evt.Test.Model
{
    public class Order : EvtBaseModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
