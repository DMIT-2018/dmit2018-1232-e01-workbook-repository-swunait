# 32.  Group By (Method Syntax)

  ##### Database
  * Westwind</br>
  ##### Setup
  * Use "C# Statement" and/or "C# Program"</br></br>
  

<details>
<summary>Group By (Part 1)</summary>

**Given a list of Payments, return the following information.**

* Payment Date (shown as Year)
* Payment Date (shown as Month)
* Payment Description (Payment)
* Total Payment (shown as Count)

* **Order Year, Month, Payment Description**  
* **We want to group the information by Year, Month and then Payment Description**

<details>
<summary>Solution</summary>

  ```cs
Payments
.GroupBy(p => new { p.PaymentDate.Year, p.PaymentDate.Month, p.PaymentType.PaymentTypeDescription })
.OrderBy(p => p.Key.Year)
.ThenBy(p => p.Key.Month)
.ThenBy(p => p.Key.PaymentTypeDescription)
.Select(p => new
{
	Year = p.Key.Year,
	Month = p.Key.Month,
	Payment = p.Key.PaymentTypeDescription,
	Count = p.Count()
}).Dump();
 ```
</details>

### Output
![](Images/32%20-%20Payment%20GroupBy.png)
</details>

--- 

</br>

[Readme.md](./Readme.md)


DMIT 2018 Take Homework<br><br>
© 2023 Northern Alberta Institute of Technology <br>
All Rights Reserved


