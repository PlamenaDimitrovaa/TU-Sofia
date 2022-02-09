import random
list = []
even = []
odd = []
for i in range(0, 10):
    n = random.randint(1,100)
    list.append(n)
print(list)

for i in list:
    if i % 2 == 0:
        even.append(i)
        even.sort(reverse = True)
    else:
        odd.append(i)
        odd.sort()
print(even)
print(odd)
