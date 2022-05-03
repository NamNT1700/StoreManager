using Entities;
using Store;
namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public RepositoryContext _repoContext;
        public ICustomersRepository _customers;
        public IEmployeesRepository _employees;
        public IOfficesRepository _offices;
        public IOrderDetailsRepository _orderDetails;
        public IOrdersRepository _orders;
        public IPaymentsRepository _payments;
        public IProductLinesRepository _productLines;
        public IProductsRepository _products;
        public ICustomersRepository Customers
        {
            get
            {
                if (_customers == null)
                {
                    _customers = new CustomersRepository(_repoContext);
                }
                return _customers;
            }
        }
        public IEmployeesRepository Employees
        {
            get
            {
                if (_employees == null)
                {
                    _employees = new EmployeesRepository(_repoContext);
                }
                return _employees;
            }
        }
        public IOfficesRepository Offices
        {
            get
            {
                if (_offices == null)
                {
                    _offices = new OfficesRepository(_repoContext);
                }
                return _offices;
            }
        }
        public IOrderDetailsRepository OrderDetails
        {
            get
            {
                if (_orderDetails == null)
                {
                    _orderDetails = new OrderDetailsRepository(_repoContext);
                }
                return _orderDetails;
            }
        }
        public IOrdersRepository Orders
        {
            get
            {
                if (_orders == null)
                {
                    _orders = new OrdersRepository(_repoContext);
                }
                return _orders;
            }
        }
        public IPaymentsRepository Payments
        {
            get
            {
                if (_payments == null)
                {
                    _payments = new PaymentsRepository(_repoContext);
                }
                return _payments;
            }
        }
        public IProductLinesRepository ProductLines
        {
            get
            {
                if (_productLines == null)
                {
                    _productLines = new ProductLinesRepository(_repoContext);
                }
                return _productLines;
            }
        }
        public IProductsRepository Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new ProductsRepository(_repoContext);
                }
                return _products;
            }
        }
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
