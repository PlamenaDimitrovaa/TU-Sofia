text = input("Insert text here: ")
dictionary = dict()
for i in text:
    dictionary[i] = ord(i)

print(dictionary)