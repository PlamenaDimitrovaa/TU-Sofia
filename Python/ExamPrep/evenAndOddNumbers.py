import math

n = int(input("Insert a number: "))
allNumbers = list()
for i in range(0, n):
    currNumber = int(input('Insert a number: '))   
    allNumbers.append(currNumber)

list1 = list()
list2 = list()

for num in allNumbers:
    if num % 2 != 0 and num % 3 == 0:
        list1.append(num)
    elif  num % 2 == 0:
        list2.append(num)

maxNum = max(list1)
minNum = min(list1)

print(minNum)
print(maxNum)

sum = sum(list2)
print(sum)
print(sum / len(list2))