using DealerPersonalAccount.Models.Entity;

namespace DealerPersonalAccount.Models.ViewModels
{
    public sealed class OperatorViewModel : IViewModel<Operator>
    {
        public OperatorViewModel(Operator operatorInstance) 
        {
            Id = operatorInstance.Id;
            Name = operatorInstance.Name;
            Tax = operatorInstance.Tax;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double Tax { get; set; }
    }
}