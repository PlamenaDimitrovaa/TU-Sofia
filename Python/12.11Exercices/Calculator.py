def add(a,b):
    result = a + b
    return result

def substract(a,b):
    result = a - b
    return result

def multiply(a,b):
    result = a*b
    return result

def divide(a,b):
    result = a/b
    return result

operation = input("Type operation: ")
a = float(input("Insert a: "))
b = float(input("Insert b: "))

if operation == "add":
    print(f"{add(a,b)}")
elif operation == "substract":
    print(f"{substract(a,b)}")
elif operation == "multiply":
    print(f"{multiply(a,b)}")
elif operation == "divide":
    print(f"{divide(a,b)}")
