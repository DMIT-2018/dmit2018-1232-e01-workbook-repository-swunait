
# 3 - Where Clause

##### Code Setup
  ```cs
  int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
  ```
  
  ##### Database
  * Westwind</br></br>

<details>
<summary>Where Clause with Numbers</summary>

**Given a list of numbers, find all numbers that are less then 6, order from smallest to largest using Query Syntax** </br>
<details>
<summary>Solution</summary>

  ```cs
(from x in numbers
 orderby x
 select x
 ).Dump();
  ```
</details>
</br>

**Given a list of numbers, find all numbers that are less then 6, order from smallest to largest using Method Syntax** </br>
<details>
<summary>Solution</summary>

```cs
numbers
.OrderBy(x => x)
.Where(x => x < 6)
.Select(x => x)
.Dump();
  ```
</details>

### Output
![](Images/3a%20-%20Where%20Clause%20Using%20Numbers.png)


---
</br>

**Given a list of numbers, find all numbers that are divisible by 2, order from largest to smallest using Query Syntax** </br>
<details>
<summary>Solution</summary>

  ```cs
(from x in numbers
 orderby x descending
 where x % 2 == 0
 select x).Dump();
  ```
</details>
</br>

**Given a list of numbers, find all numbers that are divisible by 2, order from largest to smallest using  Method Syntax** </br>
<details>
<summary>Solution</summary>

```cs
numbers
.OrderByDescending(x => x)
.Where(x => x % 2 == 0)
.Select(x => x)
.Dump();
  ```
</details>

### Output
![](Images/3b%20-%20Where%20Clause%20Using%20Numbers%20Div%202.png)
</details>

---

<details>
<summary>Where Clause Using Northwind Addresses Table</summary>

**Given a list of Addresses, find all address where country is "Canada" order by cities using Query Syntax** </br>
<details>
<summary>Solution</summary>

  ```cs
(from x in Addresses
 where x.Country == "Canada"
 orderby x.City
 select x
 ).Dump();
  ```
</details>
</br>

**Given a list of Addresses, find all address where country is "Canada" order by cities using Method Syntax** </br>
<details>
<summary>Solution</summary>

  ```cs
Addresses
.Where(x => x.Country == "Canada")
.OrderBy(x => x.City)
.Select(x => x)
.Dump();
  ```
</details>

### Output
![](Images/3b%20-%20Where%20Clause%20Using%20Table.png)
</details>

---

<details>
<summary>Multiple Where Clause Using Northwind Addresses Table</summary>

**Given a list of Addresses, find all address where country is "Canada" and city is "Vancouver" using Query Syntax** </br>
<details>
<summary>Solution</summary>

  ```cs
(from x in Addresses
 where x.Country == "Canada"  && x.City == "Vancouver"
 select x
 ).Dump();
  ```
</details>
</br>

**Given a list of Addresses, find all address where country is "Canada" and city is "Vancouver" using Method Syntax** </br>
<details>
<summary>Solution</summary>

  ```cs
Addresses
.Where(x => x.Country == "Canada" && x.City == "Vancouver")
.OrderBy(x => x.City)
.Select(x => x)
.Dump();
```
</details>

### Output
![](Images/3c%20-%20Where%20Clause%20Using%20Table.png)
</details>

---

<details>
<summary>Contains Using Northwind Addresses Table</summary>

**Given a list of Addresses, find all addresses where address contains "Rd." order by country and then by city using Query Syntax** </br>
<details>
<summary>Solution</summary>

  ```cs
(from x in Addresses
 where x.Address.Contains("Rd.")
 orderby x.Country, x.City
  select x
 ).Dump();
 ```
</details>
</br>

**Given a list of Addresses, find all addresses where address contains "Rd." order by country and then by city using Method Syntax** </br>
<details>
<summary>Solution</summary>

  ```cs
Addresses
.Where(x => x.Address.Contains("Rd."))
.OrderBy(x => x.Country)
.ThenBy(x => x.City)
.Select(x => x)
.Dump();
```
</details>

### Output
![](Images/3d%20-%20Contains%20Using%20Table.png)
</details>

---
</br>

[Readme.md](./Readme.md)


DMIT 2018 Take Homework<br><br>
© 2023 Northern Alberta Institute of Technology <br>
All Rights Reserved
