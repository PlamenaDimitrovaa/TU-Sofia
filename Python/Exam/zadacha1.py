import math
list1 = list()
list2 = list()
oddSum = 0
allNumbers = list()

while True:
    n = int(input("Insert a number: "))
    if n == 0:
        break
    else:
        if n % 2 == 0 and n % 3 == 0:
            list1.append(n)
        elif n % 2 != 0 and n % 7 == 0:
            list2.append(n)
for index in range(0, len(list1)):
    if index % 2 != 0:
        oddSum += list1[index]

print(oddSum)
list2.sort(reverse = True)
print(list2)
maxNum = max(list2)
minNum = min(list2)
print(maxNum)
print(minNum)
result = minNum * maxNum
print(result)