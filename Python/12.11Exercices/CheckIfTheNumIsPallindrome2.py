def check(number):
    startNumber = number
    reversedNumAsString = ""

    while startNumber > 0:
        digit = startNumber % 10
        startNumber = int(startNumber / 10)
        reversedNumAsString += str(digit)

    reversedNumber = int(reversedNumAsString)

    if reversedNumber == number:
        return 1
    else:
        return 0

number = int(input("Insert a number: "))

if check(number) == 1:
    print(f"{number} is pallindrome")
else:
    print(f"{number} is not pallindrome")