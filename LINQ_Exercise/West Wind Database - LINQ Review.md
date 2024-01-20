# West Wind Database - LINQ Methods

15 LINQ methods using the West Wind database to showcase various operations such as Where clauses, Sorting, Anonymous Types, Ternary Operator, Strongly Type Query, Nested Query, Aggregate, Group By, Take, Skip, FirstOrDefault, OrderBy, Any, and All. The following data model is used throughout the document:

## Data Model

```csharp
public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
    public int CategoryID { get; set; }
}

public class Category
{
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
}
```

## LINQ Methods

### 1. Get all products

<details> <summary>LINQ Query:</summary> 

```csharp
var products = from p in Products
               select p;
``` 
</details>

### 2. Get products with UnitPrice greater than 50

<details> <summary>LINQ Query:</summary> 

```csharp
var expensiveProducts = from p in Products
                        where p.UnitPrice > 50
                        select p;
```
</details>

### 3. Get products sorted by ProductName

<details> <summary>LINQ Query:</summary> 

```csharp
var sortedProducts = from p in Products
                     orderby p.ProductName
                     select p;
``` 

</details>

### 4. Get products sorted by CategoryName and then by ProductName

<details> <summary>LINQ Query:</summary> 

```csharp
var sortedProducts = from p in Products
                     join c in Categories on p.CategoryID equals c.CategoryID
                     orderby c.CategoryName, p.ProductName
                     select p;
``` 

</details>

### 5. Get products with UnitPrice greater than 50 and sorted by UnitPrice in descending order

<details> <summary>LINQ Query:</summary> 

```csharp
var sortedProducts = from p in Products
                     where p.UnitPrice > 50
                     orderby p.UnitPrice descending
                     select p;
```

</details>

### 6. Get products with UnitPrice greater than 50 and UnitInStock greater than 0

<details> <summary>LINQ Query:</summary>  

```csharp
var inStockProducts = from p in Products
                      where p.UnitPrice > 50 && p.UnitsInStock > 0
                      select p;
``` 

</details>

### 7. Get products with UnitPrice greater than 50 or UnitInStock greater than 0

<details> <summary>LINQ Query:</summary>  

```csharp
var availableProducts = from p in Products
                        where p.UnitPrice > 50 || p.UnitsInStock > 0
                        select p;
``` 

</details>

### 8. Get products with anonymous type

<details> <summary>LINQ Query:</summary>  

```csharp
var productInfo = from p in Products
                  select new { p.ProductName, p.UnitPrice };
``` 

</details>

### 9. Get products with anonymous type and calculated field

<details> <summary>LINQ Query:</summary>  

```csharp
var productInfo = from p in Products
                  select new { p.ProductName, p.UnitPrice, DiscountedPrice = p.UnitPrice * 0.9m };
``` 

</details>

### 10. Get products with UnitPrice greater than 50 and sorted by UnitPrice in descending order using ternary operator

<details> <summary>LINQ Query:</summary>  

```csharp
var sortedProducts = from p in Products
                     where p.UnitPrice > 50
                     orderby p.UnitPrice > 100 ? p.UnitPrice * 0.9m : p.UnitPrice descending
                     select p;
``` 

</details>

### 11. Get products with UnitPrice greater than 50 and sorted by UnitPrice in descending order using strongly typed query

<details> <summary>LINQ Query:</summary>  

```csharp
var sortedProducts = Products
                     .Where(p => p.UnitPrice > 50)
                     .OrderByDescending
``` 

</details>                     

## Review Question - West Wind Database using LINQ

1. What is LINQ and how does it work with the West Wind database?
2. What are the different types of LINQ methods used with the West Wind database?
3. What is the LINQ query to get all products from the West Wind database?
4. How do you get products with UnitPrice greater than 50 from the West Wind database using LINQ?
5. How do you sort products by ProductName in the West Wind database using LINQ?
6. How do you sort products by CategoryName and then by ProductName in the West Wind database using LINQ?
7. How do you get products with UnitPrice greater than 50 and sorted by UnitPrice in descending order from the West Wind database using LINQ?
8. How do you get products with UnitPrice greater than 50 and UnitInStock greater than 0 from the West Wind database using LINQ?
9. How do you get products with UnitPrice greater than 50 or UnitInStock greater than 0 from the West Wind database using LINQ?
10. How do you get products with anonymous type from the West Wind database using LINQ?