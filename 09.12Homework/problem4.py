def func(code):
    nletters = code - 80
    list1 = []
    if nletters > 0:
        for i in range (nletters):
            list1.append(chr(i + 97))
            if i > 24:
                break
    else:
        for i in range(-nletters):
            list1.append(chr(122 - i))
            if i > 24:
                break
    return list1

text = input("Enter your text: ")
textcodes = []
for i in text:
    textcodes.append(ord(i))
sortedtextcode = textcodes
sortedtextcode.sort()
tuple = tuple(sortedtextcode)
d1 = {}
for i in textcodes:
    d1[i] = func(i)
print (d1)