# 5 - Strongly Types (Method Syntax)

  ##### Database
  * Westwind</br>
  ##### Setup
  * Use C# Program</br></br>

<details>
<summary>Simple Strongly Type</summary>

**Given a list of Payment Types, return the following information as a strongly type list.**

  * Payment Type ID (shown as PaymentTypeID)
  * Description (shown as Description)

**NOTE:  The strongly type name will be PaymentTypeView**
  

<details>
<summary>Solution</summary>

  ```cs
void Main()
{
	PaymentTypes
	.Select(x => new PaymentTypeView()
	{
		PaymentTypeID = x.PaymentTypeID,
		Description = x.PaymentTypeDescription
	})
	.Dump();
}

public class PaymentTypeView
{
	public int PaymentTypeID { get; set; }
	public string Description { get; set; }	
}
 ```
</details>

### Output
![](Images/5a%20-%20Simple%20Strongly.png)
</details>

---

<details>
<summary>Simple Strongly Type (Part 2)</summary>

**Given a list of Customer, return the following information as a strongly type list.**

  * Customer ID (shown as CustomerId)
  * Company Name (shown as Company)
  * Contact Name (shown as Name)
  * Contact Position (shown as Position)
  * City
  * Country
  * **Where the companies are in North America**
  * **Order by Country, Company Name**
  
**NOTE:  The strongly type name will be CompanyView**
  

<details>
<summary>Solution</summary>

  ```cs
void Main()
{
	Customers
	.Where(x => x.Address.Country == "Canada"
				|| x.Address.Country == "Mexico"
				|| x.Address.Country == "USA")
	.OrderBy(x => x.Address.Country)
	.ThenBy(x => x.CompanyName)
	.Select(x => new CompanyView()
	{
		CustomerID = x.CustomerID,
		Company = x.CompanyName,
		Name = x.ContactName,
		Position = x.Address.Address,
		City = x.Address.City,
		Country = x.Address.Country
	})
	.Dump();
}

public class CompanyView
{
	public string CustomerID { get; set; }
	public string Company { get; set; }
	public string Name { get; set; }
	public string Position { get; set; }
	public string City { get; set; }
	public string Country { get; set; }
}
 ```
</details>

### Output
![](Images/5b%20-%20Simple%20Strongly%20Part%202.png)
</details>

---

</br>

[Readme.md](./Readme.md)


DMIT 2018 Take Homework<br><br>
© 2023 Northern Alberta Institute of Technology <br>
All Rights Reserved
