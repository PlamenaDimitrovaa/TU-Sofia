n = int(input("Insert a number: "))
dictionary = {}
try:
    for x in range(n):
        inputNum = int(input("Insert your number: "))
        stringValue = ''
        if inputNum < 0:
            raise ValueError
        for x in range(inputNum):
            stringValue += chr(x + 97)

        dictionary[inputNum] = stringValue
except ValueError:
    print("Invalid number")
finally:
    print(dictionary)