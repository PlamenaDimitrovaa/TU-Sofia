text = input("Insert text here:")
list = []
for i in text:
    list.append(i)
print(list)
print(list[::-1])
list1 = []
for i in text:
    list1.append(ord(i))
print(list1)
list1.sort()
print(list1)