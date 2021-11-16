namespace Store
{
    public interface IRepositoryWrapper
    {
        ICustomersRepository Customers { get; }
        IEmployeesRepository Employees { get; }
        IOfficesRepository Offices { get; }
        IOrderDetailsRepository OrderDetails { get; }
        IOrdersRepository Orders { get; }
        IPaymentsRepository Payments { get; }
        IProductLinesRepository ProductLines { get; }
        IProductsRepository Products { get; }
        void Save();
    }
}
