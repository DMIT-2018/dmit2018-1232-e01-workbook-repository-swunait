# Level 50 (The Boss Level)
###  These examples expands on knowledge that you have learn within the class to give you a challenge in what is possible using LINQ syntax.
---
<br>

  ##### Database
  * Westwind</br></br>
  
  <details>
<summary>Advance Anonymous Dataset using Ternary Operator & Aggregate Operator</summary>

**Given a list of Address, return the following information:** </br>
  * Address ID 
  * Name 
    * Use the ternary operator and the navigation property to get one of the following data values.  You will also needs to use the .any aggregate
      * Customers -> CompanyName
      * Employees -> First & Last name
      * Orders -> ShipName
      * Suppliers -> CompanyName
      * Null values -> Unknown
  * Address Type
    * Use the ternary operator and the navigation property to get one of the following data values
      * Customers -> Customer
      * Employees -> Employee
      * Orders -> Order
      * Suppliers -> Supplier
      * Null values -> Unknown
  * Address
  * City 
  * Region *(If the region is null then list it as "Unknown")*
  * Country
  * **Order by Country, Address ID**

<details>
<summary>Solution</summary>

  ```cs
Addresses
.OrderBy(x => x.Country)
.ThenBy(x => x.AddressID)
.Select(x => new
{
		Name = Customers.Any(c => c.AddressID == x.AddressID) 
		? Customers.Where(c => c.AddressID == x.AddressID)
			.Select(c => c.CompanyName).FirstOrDefault() 
		: x.Employees.Any(e => e.AddressID == x.AddressID) 
		? Employees.Where(e => e.AddressID == x.AddressID)
			.Select(e => e.FirstName + " " + e.LastName).FirstOrDefault()
		: Orders.Any(o => o.ShipAddressID == x.AddressID) 
		? Orders.Where(o => o.ShipAddressID == x.AddressID)
			.Select(o => o.ShipName).FirstOrDefault()
		: Suppliers.Any(s => s.AddressID == x.AddressID)
		? Suppliers.Where(s => s.AddressID == x.AddressID)
			.Select(s => s.CompanyName).FirstOrDefault()
		: "Unknown",
	AddressID = x.AddressID,
	AddressType = Customers.Any(c => c.AddressID == x.AddressID)
		? "Customer"
		: x.Employees.Any(e => e.AddressID == x.AddressID)
		? "Employee"
		: Orders.Any(o => o.ShipAddressID == x.AddressID)
		? "Order"
		: Suppliers.Any(s => s.AddressID == x.AddressID)
		? "Supplier"
		: "Unknown",
	Address = x.Address,
	City = x.City,
	Region = x.Region != null ? x.Region : "Unknown",
	Country = x.Country
}).Dump();
 ```
</details>

### Output
![](Images/50a%20-%20Advance%20Anonymous%20Dataset%20using%20Ternary%20Operator%20&%20Aggregate%20Operator.png)
</details>

---

<br>

[Readme.md](./Readme.md)


DMIT 2018 Take Homework<br><br>
© 2023 Northern Alberta Institute of Technology <br>
All Rights Reserved
