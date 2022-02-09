number = int(input('Insert a number: '))
listOfNums = list()

for i in range(1, number + 1):
    listOfNums.append(i)
dict = dict()

for i in range(0, len(listOfNums)):
    dict[listOfNums[i]] = listOfNums[len(listOfNums) - 1 - i]

print(dict)
