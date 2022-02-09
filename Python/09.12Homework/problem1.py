text = input("Insert text: ")
tuple1 = tuple(text)
tuple2 = tuple(text[::1])
textList = list()
for i in text:
    textList.append(ord(i))

tuple3 = tuple(textList)
textList.sort()
tuple4 = tuple(textList)
print(tuple1)
print(tuple2)
print(tuple3)
print(tuple4)
