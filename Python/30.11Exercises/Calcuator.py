sign = input("Insert a sign: ")
while True:
    try:
        num1 = int(input("Insert a num: "))
        num2 = int(input("Insert a num: "))
    except ValueError:
        print("Invalid number.Try again..")
    else:
        break
if sign == '+':
    print(num1 + num2)
elif sign == '-':
    print(num1 - num2)
elif sign == '*':
    print(num1 * num2)
elif sign == '/':
    print(num1/num2)
else:
    print("Invalid sign. Try again...")