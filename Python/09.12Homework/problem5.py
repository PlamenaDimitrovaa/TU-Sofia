def Add(a,b):
    return a + b
def Subtract(a,b):
    return a - b
def Divide(a,b):
     return a / b
def Multiply(a,b):
    return a * b

sign = input("Choose a sign: + or - or * or /")

while True:
    try:
        firstNum = int(input("Insert a num: "))
        secondNum = int(input("Insert a num: "))
    except ValueError:
        print("Invalid number, input new numbers")
        continue

    result = 0

    if sign == '+':
        result = Add(firstNum,secondNum)
    elif sign == '-':
        result = Subtract(firstNum, secondNum)
    elif sign == '/':
        result = Divide(firstNum, secondNum)
    elif sign == '*':
        result = Multiply(firstNum, secondNum)

    break

print(f"{firstNum} {sign} {secondNum} = {result}")
