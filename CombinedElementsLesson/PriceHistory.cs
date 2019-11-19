using System;

namespace CombinedElementsLesson
{
    public class PriceHistory
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public Guid CompanyId { get; set; }
    }
}