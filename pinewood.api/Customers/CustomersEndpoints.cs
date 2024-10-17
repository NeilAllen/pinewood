using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using pinewood.api.Dtos;
using pinewood.api.Models;

namespace pinewood.api.Customers
{
    public static class CustomersEndpoints
	{
        public static void RegisterCustomersEndpoints(this WebApplication app)
        {
            var customers = app.MapGroup("/customers");

            customers.MapGet("/", GetAllCustomers);
            customers.MapGet("/{id}", GetCustomerById);
            customers.MapPost("/", CreateCustomer);
            customers.MapPut("/{id}", UpdateCustomer);
            customers.MapDelete("/{id}", DeleteCustomer);
        }
        #region lambda methods

        static async Task<Results<Ok<Customer>, NotFound>> GetCustomerById(int id, CustomerDb db) =>
            await db.Customers.FindAsync(id)
                is Customer customer
                    ? TypedResults.Ok(customer)
                    : TypedResults.NotFound();

        static async Task<IResult> GetAllCustomers(CustomerDb db)
        {
            return TypedResults.Ok(await db.Customers.Select(x => new CustomerDTO(x)).ToArrayAsync());
        }

        static async Task<IResult> GetCustomer(int id, CustomerDb db)
        {
            return await db.Customers.FindAsync(id)
                is Customer customer
                    ? TypedResults.Ok(new CustomerDTO(customer))
                    : TypedResults.NotFound();
        }

        static async Task<IResult> CreateCustomer(CustomerDTO customerDTO, CustomerDb db)
        {
            var customer = new Customer
            {
                Name = customerDTO.Name,
                EmailAddress = customerDTO.EmailAddress,
                PostalAddress = customerDTO.PostalAddress,
                PostalCode = customerDTO.PostalCode,
                TelephoneNumber = customerDTO.TelephoneNumber
            };

            db.Customers.Add(customer);
            await db.SaveChangesAsync();

            customerDTO = new CustomerDTO(customer);

            return TypedResults.Created($"/customers/{customer.Id}", customerDTO);
        }

        static async Task<IResult> UpdateCustomer(int id, CustomerDTO customerDTO, CustomerDb db)
        {
            var customer = await db.Customers.FindAsync(id);

            if (customer is null) return TypedResults.NotFound();

            customer.Name = customerDTO.Name;
            customer.EmailAddress = customerDTO.EmailAddress;
            customer.PostalAddress = customerDTO.PostalAddress;
            customer.PostalCode = customerDTO.PostalCode;
            customer.TelephoneNumber = customerDTO.TelephoneNumber;

            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        }

        static async Task<IResult> DeleteCustomer(int id, CustomerDb db)
        {
            if (await db.Customers.FindAsync(id) is Customer customer)
            {
                db.Customers.Remove(customer);
                await db.SaveChangesAsync();
                return TypedResults.NoContent();
            }

            return TypedResults.NotFound();
        }
        #endregion
    }
}

