# 33.  Odds & Ends (Method Syntax)

  ##### Database
  * Westwind</br>
  ##### Setup
  * Use "C# Statement" and/or "C# Program"</br></br>
  <details>
<summary>Take/Skip</summary>

**Given a list of Orders, return the following information.**

* Order ID
* Order Date
* Customer Name
* **Using Take, get the first 10 records**

<details>
<summary>Solution</summary>

  ```cs
//  Using take on the order collection
Orders
//  order by must be done before take
.OrderBy(x => x.OrderID)
.Take(10)
.Select(x => new
{
	OrderID = x.OrderID,
	OrderDate = x.OrderDate,
	Customer = x.Customer.CompanyName
}).Dump();

//  Using take of the collection created from the select
Orders
//  order by must be done before take
.OrderBy(x => x.OrderID)
.Select(x => new
{
	OrderID = x.OrderID,
	OrderDate = x.OrderDate,
	Customer = x.Customer.CompanyName
})
.Take(10)
.Dump();
 ```
</details>

### Output
![](Images/33%20-%20Odds%20and%20Ends%201.png)

--- 
**Given a list of Orders, return the following information.**

* Order ID
* Order Date
* Customer Name
* **Using Skip and Take, Skip the first 5 records and Take the next 10**

<details>
<summary>Solution</summary>

  ```cs
//  Using take on the order collection
Orders
//  order by must be done before take
.OrderBy(x => x.OrderID)
.Skip(5)
.Take(10)
.Select(x => new
{
	OrderID = x.OrderID,
	OrderDate = x.OrderDate,
	Customer = x.Customer.CompanyName
}).Dump();

//  Using take of the collection created from the select
Orders
//  order by must be done before take
.OrderBy(x => x.OrderID)
.Select(x => new
{
	OrderID = x.OrderID,
	OrderDate = x.OrderDate,
	Customer = x.Customer.CompanyName
})
.Skip(5)
.Take(10)
.Dump();
 ```
</details>

### Output
![](Images/33%20-%20Odds%20and%20Ends%202.png)

--- 
</details>

--- 
<details>
<summary>Any</summary>

**Given 2 Customer (Bergs & Hungo), return the following information.**

* Category
* Product Name (show as Name)
* **Order by Category and Product Name**  
* **We only want to see the following:**
  * **Those products that were purchase by both customers**
  

<details>
<summary>Solution</summary>

  ```cs
void Main()
{
	//  get products used by Bergs
	var customer1 =
		OrderDetails
			.Where(x => x.Order.Customer.CustomerID.Equals("BERGS"))
			.Select(x => new
			{
				ProductID = x.ProductID,
				Product = x.Product.ProductName,
				Category = x.Product.Category.CategoryName
			}
			)
			.Distinct()
			.OrderBy(x => x.ProductID);
	
	//  get products used by Hungo
	var customer2 =
		OrderDetails
			.Where(x => x.Order.Customer.CustomerID.Equals("HUNGO"))
			.Select(x => new
			{
				ProductID = x.ProductID,
				Product = x.Product.ProductName,
				Category = x.Product.Category.CategoryName
			}
			)
			.Distinct()
			.OrderBy(x => x.ProductID);


	//  get all product that Bergs uses that is also used by Hungo
	customer1
	.Where(c1 => customer2.Any(c2 => c2.ProductID == c1.ProductID))
	.Select(x => new
	{
		Category = x.Category,
		Product = x.Product
	})
			.OrderBy(x => x.Category)
			.ThenBy(x => x.Product)
			.Dump();
}

 ```
</details>

### Output
![](Images/33%20-%20Any%203.png)
</details>

--- 


</br>

[Readme.md](./Readme.md)


DMIT 2018 Take Homework<br><br>
© 2023 Northern Alberta Institute of Technology <br>
All Rights Reserved


