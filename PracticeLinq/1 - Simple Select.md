# 1 - Simple Select

##### Code Setup
  ```cs
  int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
  ```


##### Given a list of numbers, select all numbers using Query Syntax
<details>
<summary>Solution</summary>

  ```cs
(from x in numbers
 select x).Dump();
  ```
</details>

##### Given a list of numbers, select all numbers using Method Syntax
<details>
<summary>Solution</summary>

  ```cs
numbers.Select(x => x).Dump();
  ```
</details>

### Output

![](Images/1a%20-%20Simple%20Select.png)

---
</br>

[Readme.md](./Readme.md)


DMIT 2018 Take Homework<br><br>
© 2023 Northern Alberta Institute of Technology <br>
All Rights Reserved
