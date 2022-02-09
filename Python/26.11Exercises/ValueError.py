import math

try:
    number = int(input('Insert a number: '))
    print(math.sqrt(number))
except ValueError:
    print('Invalid number')
finally:
    print('Good Bye')