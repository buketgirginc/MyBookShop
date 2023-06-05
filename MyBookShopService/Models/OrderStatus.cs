using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBookShopService.Models
{
    [Table("OrderStatus")]
    public class OrderStatus
    {
        public int Id { get; set; }
        [Microsoft.Build.Framework.Required]
        public int StatusId { get; set; }
        [Microsoft.Build.Framework.Required, MaxLength(20)]
        public string ?StatusName { get; set; }
    }
}
