str = input('Enter a string: ')
dictionary = {}
for i in str:
    a = ord(i)
    b =a  
    sum = 0

    while a!= 0:
        k = a% 10
        a = a//10
        sum = sum + k
    dictionary[b] = sum

print(dictionary)