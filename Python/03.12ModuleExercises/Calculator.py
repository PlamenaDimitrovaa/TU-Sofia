import mymodule
sign = input("Insert a sign: ")
num1 = float(input("Insert num1: "))
num2 = float(input("Insert num2: "))
if sign == '+':
    print(mymodule.sum(num1,num2))

elif sign == '-':
    print(mymodule.subtract(num1,num2))

elif sign == '*':
    print(mymodule.multiply(num1,num2))

elif sign == '/':
    print(mymodule.divide(num1,num2))

else:
    print("Invalid sign. Try again...")
    


