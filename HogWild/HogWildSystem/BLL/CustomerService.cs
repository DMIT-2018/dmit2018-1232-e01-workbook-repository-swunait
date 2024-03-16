using DMIT2018.Paginator;
using HogWildSystem.DAL;
using HogWildSystem.Entities;
using HogWildSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogWildSystem.BLL
{
    public class CustomerService
    {
        #region Fields

        /// <summary>
        /// The hog wild context
        /// </summary>
        private readonly HogWildContext _hogWildContext;

        #endregion

        // Constructor for the WorkingVersionsService class.
        internal CustomerService(HogWildContext hogWildContext)
        {
            // Initialize the _hogWildContext field with the provided HogWildContext instance.
            _hogWildContext = hogWildContext;
        }

        public List<CustomerSearchView> GetCustomers(string lastName, string phone)
        {
            // Business Rules
            // These are processing rules that need to be satisfied
            // for valid data

            // Rule: Both last name and phone number cannot be empty
            // Rule: RemoveFromViewFlag must be false
            if (string.IsNullOrWhiteSpace(lastName) && string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentNullException("Please provide either a last name and/or phone number");
            }

            // Need to update parameters so we are not searching on an empty value.
            // Otherwise, an empty string will return all records
            if (string.IsNullOrWhiteSpace(lastName))
            {
                lastName = Guid.NewGuid().ToString();
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                phone = Guid.NewGuid().ToString();
            }

            return _hogWildContext.Customers
                .Where(x => (x.LastName.Contains(lastName)
                             || x.Phone.Contains(phone))
                            && !x.RemoveFromViewFlag)
                .Select(x => new CustomerSearchView
                {
                    CustomerID = x.CustomerID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    City = x.City,
                    Phone = x.Phone,
                    Email = x.Email,
                    StatusID = x.StatusID,
                    TotalSales = x.Invoices.Sum(x => x.SubTotal + x.Tax)
                })
                .OrderBy(x => x.LastName)
                .ToList();
        }
   
        public Task<PagedResult<CustomerSearchView>> GetCustomers(
            string lastName,
            string phone,
            int page,
            int pageSize,
            string sortColumn,
            string direction
            )
        {
            // Business Rules
            // These are processing rules that need to be satisfied
            // for valid data

            // Rule: Both last name and phone number cannot be empty
            // Rule: RemoveFromViewFlag must be false
            if (string.IsNullOrWhiteSpace(lastName) && string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentNullException("Please provide either a last name and/or phone number");
            }

            // Need to update parameters so we are not searching on an empty value.
            // Otherwise, an empty string will return all records
            if (string.IsNullOrWhiteSpace(lastName))
            {
                lastName = Guid.NewGuid().ToString();
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                phone = Guid.NewGuid().ToString();
            }

            return Task.FromResult(_hogWildContext.Customers
                .Where(x => (x.LastName.Contains(lastName)
                             || x.Phone.Contains(phone))
                            && !x.RemoveFromViewFlag)
                .Select(x => new CustomerSearchView
                {
                    CustomerID = x.CustomerID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    City = x.City,
                    Phone = x.Phone,
                    Email = x.Email,
                    StatusID = x.StatusID,
                    TotalSales = x.Invoices.Sum(x => x.SubTotal + x.Tax)
                })
                .AsQueryable()
                .OrderBy(sortColumn, direction)
                .ToPagedResult(page, pageSize));
        }

        public CustomerEditView GetCustomer(int customerID)
        {
            //  Business Rules
            //	These are processing rules that need to be satisfied
            //		for valid data
            //		rule:	customerID must be valid 

            if (customerID == 0)
            {
                throw new ArgumentNullException("Please provide a customer");
            }

            return _hogWildContext.Customers
                .Where(x => (x.CustomerID == customerID
                             && x.RemoveFromViewFlag == false))
                .Select(x => new CustomerEditView
                {
                    CustomerID = x.CustomerID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    City = x.City,
                    ProvStateID = x.ProvStateID,
                    CountryID = x.CountryID,
                    PostalCode = x.PostalCode,
                    Phone = x.Phone,
                    Email = x.Email,
                    StatusID = x.StatusID,
                    RemoveFromViewFlag = x.RemoveFromViewFlag
                }).FirstOrDefault();
        }

        //  Customer Save
        public CustomerEditView Save(CustomerEditView editCustomer)
        {
            #region Business Logic and Parameter Exceptions
            //	create a list<Exception> to contain all discovered errors
            List<Exception> errorList = new List<Exception>();
            //  Business Rules
            //	These are processing rules that need to be satisfied
            //		for valid data

            //		rule:	customer cannot be null	
            if (editCustomer == null)
            {
                throw new ArgumentNullException("No customer was supply");
            }

            //		rule: 	first name, last name, phone number and email are required (not empty)
            if (string.IsNullOrWhiteSpace(editCustomer.FirstName))
            {
                errorList.Add(new Exception("First name is required"));
            }

            if (string.IsNullOrWhiteSpace(editCustomer.LastName))
            {
                errorList.Add(new Exception("Last name is required"));
            }

            if (string.IsNullOrWhiteSpace(editCustomer.Email))
            {
                errorList.Add(new Exception("Email is required"));
            }

            if (string.IsNullOrWhiteSpace(editCustomer.Phone))
            {
                errorList.Add(new Exception("Phone is required"));
            }

            //		rule: 	first name, last name and phone number cannot be duplicated (found more than once)
            if (editCustomer.CustomerID == 0)
            {
                bool customerExist = _hogWildContext.Customers
                                .Where(x => x.FirstName == editCustomer.FirstName
                                            && x.LastName == editCustomer.LastName
                                            && x.Phone == editCustomer.Phone)
                                .Any();

                if (customerExist)
                {
                    errorList.Add(new Exception("Customer already exist in the database and cannot be enter again"));
                }
            }
            #endregion

            Customer customer =
                _hogWildContext.Customers.Where(x => x.CustomerID == editCustomer.CustomerID)
                    .Select(x => x).FirstOrDefault();

            //  new customer
            if (customer == null)
            {
                customer = new Customer();
            }

            customer.FirstName = editCustomer.FirstName;
            customer.LastName = editCustomer.LastName;
            customer.Address1 = editCustomer.Address1;
            customer.Address2 = editCustomer.Address2;
            customer.City = editCustomer.City;
            customer.ProvStateID = editCustomer.ProvStateID;
            customer.CountryID = editCustomer.CountryID;
            customer.PostalCode = editCustomer.PostalCode;
            customer.Email = editCustomer.Email;
            customer.Phone = editCustomer.Phone;
            customer.StatusID = editCustomer.StatusID;
            customer.RemoveFromViewFlag = editCustomer.RemoveFromViewFlag;

            if (errorList.Count > 0)
            {
                //  we need to clear the "track changes" otherwise we leave our entity system in flux
                _hogWildContext.ChangeTracker.Clear();
                //  throw the list of business processing error(s)
                throw new AggregateException("Unable to add or edit customer. Please check error message(s)", errorList);
            }
            else
            {
                //  new customer
                if (customer.CustomerID == 0)
                    _hogWildContext.Customers.Add(customer);
                else
                    _hogWildContext.Customers.Update(customer);
                _hogWildContext.SaveChanges();
            }
            //  can return current editCustomer
            editCustomer.CustomerID = customer.CustomerID;
            return editCustomer;
        }
    }
}
