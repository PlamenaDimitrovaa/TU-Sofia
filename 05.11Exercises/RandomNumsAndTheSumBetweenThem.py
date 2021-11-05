import random 
list = []

for i in range(0, 5):
    n = random.randint(1,30)
    list.append(n)
print(list)

result = list()

for i in range(0, len(list) - 1 ):
    sum = list[i] + list[i + 1]
    if i == 0:
        result.append(list[i])
    result.append(sum)
    result.append(list[i +1])
    
print(result)