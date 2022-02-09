text = input("Insert your string here: ")
list = list(text)
dictionary = {}
for i in range(len(list)):
    n = int(ord(list[i]))
    sum = 0
    while True:
        sum+= n % 10
        n = n//10
        if n == 0:
            break
    dictionary[ord(list[i])] = sum  
print(dictionary)