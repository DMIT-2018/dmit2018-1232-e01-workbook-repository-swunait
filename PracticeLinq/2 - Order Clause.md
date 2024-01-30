# 2 - Order Clause

##### Code Setup
  ```cs
  int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
  string[] words = {"cherry", "apple", "blueberry"};
  string[] digits = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
  ```
  
  ##### Database
  * Westwind</br></br>

<details>
<summary>Ascending Order (smallest to largest)</summary>

**Given a list of numbers, order all numbers using Query Syntax** </br>
NOTE: Result type is IOrderedEnumerable&lt;Int32&gt;
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

**Given a list of numbers, order all numbers using Method Syntax** </br>
<details>
<summary>Solution</summary>

  ```cs
numbers.OrderBy(x => x)
.Select(x => x)
.Dump();
  ```
</details>

### Output
![](Images/2a%20-%20Simple%20Select%20Using%20Ordering.png)

---
</br>

**Given a list of words, order all words by length using Query Syntax** </br>
<details>
<summary>Solution</summary>

  ```cs
(from x in words
orderby x.Length
select x
 ).Dump();
  ```
</details>

**Given a list of words, order all words by length using Method Syntax** </br>
NOTE: Result type is IEnumerable&lt;string&gt;
<details>
<summary>Solution</summary>

  ```cs
 words
 .OrderBy(x => x.Length)
 .Select(x => x)
 .Dump();
  ```
</details>

### Output
![](Images/2b%20-%20Simple%20Select%20Using%20Ordering%20by%20Length.png)
</details>

---
<details>
<summary>Descending Order (largest to smallest)</summary>

**Given a list of numbers, order all numbers from largest to smallest using Query Syntax** </br>
<details>
<summary>Solution</summary>

  ```cs
(from x in numbers
 orderby x descending
 select x
 ).Dump();
  ```
</details>
</br>

**Given a list of numbers, order all numbers from largest to smallest using Method Syntax** </br>
NOTE: Result type is IEnumerable&lt;Int32&gt;
<details>
<summary>Solution</summary>

  ```cs
numbers.OrderByDescending(x => x)
.Select(x => x)
.Dump();
  ```
</details>

### Output
![](Images/2c%20-%20Simple%20Select%20Using%20Descending%20Ordering.png)
</details>

---
<details>
<summary>Then By Ordering (property 1 then by property 2)</summary>

**Given a list of digits, order all digits by word length then alphabetical using Query Syntax** </br>

<details>
<summary>Solution</summary>

  ```cs
(from x in digits
 orderby x.Length, x
 select x
 ).Dump();
  ```
</details>
</br>

**Given a list of digits, order all digits by word length then alphabetical using Method Syntax** </br>
NOTE: Result type is IEnumerable&lt;String&gt;
<details>
<summary>Solution</summary>

  ```cs
digits
.OrderBy(x => x.Length)
.ThenBy(x => x)
.Select(x => x)
.Dump();
  ```
</details>

### Output
![](Images/2d%20-%20Simple%20Select%20Using%20Then.png)
</details>

---
<details>
<summary>Then By Ordering Using Northwind Addresses Table</summary>

**Given a list of Addresses, order all address by country then city using Query Syntax** </br>
<details>
<summary>Solution</summary>

  ```cs
(from x in Addresses
 orderby x.Country,x.City
 select x
 ).Dump();
  ```
</details>
</br>

**Given a list of Addresses, order all address by country then city using Method Syntax** </br>
<details>
<summary>Solution</summary>

  ```cs
Addresses
.OrderBy(x => x.Country)
.ThenBy(x => x.City)
.Select(x => x)
.Dump();
  ```
</details>

### Output
![](Images/2e%20-%20Simple%20Select%20Using%20Then%20with%20Table.png)
</details>

---
</br>

[Readme.md](./Readme.md)


DMIT 2018 Take Homework<br><br>
© 2023 Northern Alberta Institute of Technology <br>
All Rights Reserved
