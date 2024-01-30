
# 4 - Anonymous Types (Method Syntax)

  ##### Database
  * Westwind</br></br>

<details>
<summary>Simple Anonymous Dataset</summary>

**Given a list of Employees, return the following information:** </br>
  * Employee ID (shown as CompanyId)  *Note: Company ID is how the company  reference their employee ID*
  * First Name (shown as Name)
  * Last Name (shown as Surname)
  * Job Title (shown as Position)
  * **Order by last name**

<details>
<summary>Solution</summary>

  ```cs
Employees
.OrderBy(x => x.LastName)
.Select(x => new
{
	CompanyId = x.EmployeeID,
	Name = x.FirstName,
	Surname = x.LastName,
	Position = x.JobTitle
})
.Dump();
 ```
</details>

### Output
![](Images/4a%20-%20Simple%20Anonymous.png)
</details>

---

<details>
<summary>Simple Anonymous Dataset (Part 2)</summary>

**Given a list of Employees, return the following information:** </br>
  * Employee ID (shown as CompanyId)
  * First & Last Name (shown as FullName) 
  * Job Title (shown as Position)
  * Hire Date (format as year/month/date) *No time value*
    * *You may need to google on how to do the date formatting*
  * **Where the hire date is greater or equal to May 3, 2014**
    * *You will need to used the "Parse" function from the DateTime value type*
  * **Order by last name**
  


<details>
<summary>Solution</summary>

  ```cs
Employees
.Where(x => x.HireDate >= DateTime.Parse("05/03/2014"))
.OrderBy(x => x.LastName)
.Select(x => new
{
	EmployeeID = x.EmployeeID,
	FullName = x.FirstName + " " + x.LastName,
	Position = x.JobTitle,
	//  The @ symbol allows for you to escape the "/" character.  
	//	Otherwise you would need to a double "/"  IE:  {x.HireDate.Year}//{x.HireDate.Month}
	HireDate = $@"{x.HireDate.Year}/{x.HireDate.Month}/{x.HireDate.Day}"
})
.Dump();
 ```
</details>

### Output
![](Images/4b%20-%20Simple%20Anonymous%20Part%202.png)
</details>

---
<details>
<summary>Simple Anonymous Dataset using Navigation Properties</summary>

**Given a list of Customer, return the following information:** </br>
  * Customer ID (shown as CustomerNo)
  * Company Name (shown as Name)
  * Contact Name 
  * Address
  * City
  * Country
  * **Where the companies are in North America**
  * **Order by Country, Company Name**

<details>
<summary>Solution</summary>

  ```cs
Customers
.Where(x => x.Address.Country == "Canada"
			|| x.Address.Country == "Mexico"
			|| x.Address.Country == "USA")
			
//  You can also use the ".Equals" method
//.Where(x => x.Address.Country.Equals("Canada")
//			|| x.Address.Country.Equals("Mexico")
//			|| x.Address.Country.Equals("USA"))

.OrderBy(x => x.Address.Country)
.ThenBy(x => x.CompanyName)
.Select(x => new
{
	CustomerNo = x.CustomerID,
	Name = x.CompanyName,
	ContactName = x.ContactName,
	Address = x.Address.Address,
	City = x.Address.City,
	Country = x.Address.Country
})
.Dump();
 ```
</details>

### Output
![](Images/4c%20-%20Simple%20Anonymous%20with%20Nav%20Prop.png)
</details>

---

</br>

[Readme.md](./Readme.md)


DMIT 2018 Take Homework<br><br>
© 2023 Northern Alberta Institute of Technology <br>
All Rights Reserved
