using Domain.Models;

namespace Data.Repository.Entity.Context
{
    public class Maintenance : BaseEntity
    {
        public string Item { get; set; }
        public string Operation { get; set; }
        public int Every { get; set; }
    }
}
