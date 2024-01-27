using System;

namespace DealerPersonalAccount.Models.Entity
{
    public sealed class Payment
    {
        public int Id { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? ClosingDateTime { get; set; }
        public int? OperatorId { get; set; }
        public int? AgentId { get; set; }
        public double Price { get; set; }
    }
}