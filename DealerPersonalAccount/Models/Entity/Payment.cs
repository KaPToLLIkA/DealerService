using System;

namespace DealerPersonalAccount.Models.Entity
{
    public sealed class Payment
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ClosingTime { get; set; }
        public int? OperatorId { get; set; }
        public int? AgentId { get; set; }
        public double Price { get; set; }
    }
}