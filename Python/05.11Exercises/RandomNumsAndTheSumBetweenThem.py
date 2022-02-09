import random 
lista = list()

for i in range(0, 5):
    n = random.randint(1,30)
    lista.append(n)
print(lista)

result = list()

for i in range(0, len(lista) - 1 ):
    sum = lista[i] + lista[i + 1]
    if i == 0:
        result.append(lista[i])
    result.append(sum)
    result.append(lista[i +1])
    
print(result)