import math
num1 = int(input("Insert a number: "))
try:
    print(math.sqrt(num1))
except ValueError:
    print("Invalid number")
finally:
    print("Goodbye")
