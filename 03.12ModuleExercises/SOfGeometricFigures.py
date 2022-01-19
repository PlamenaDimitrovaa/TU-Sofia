def triangle(a,b):
    S = (a * b)/2 
    print(S)
    return S

def square(a):
    S = (a * a)
    print(S)
    return S

def rectangle(a,b):   
    S = (a * b)
    print(S)
    return S

def rhombus(a,h):
    S = (a * h)
    print(S)
    return S

def trapeze(a,b,h):
    S = ((a + b)*h)/2
    print(S)
    return S

type = input("Insert type of the figure: ")
if type == "triangle":
    a = float(input("Insert a number: "))
    b = float(input("Insert a number: "))
    triangle(a,b)
elif type == "square":
    a = float(input("Insert a number: "))   
    square(a)
elif type == "rectangle":
    a = float(input("Insert a number: ")) 
    b = float(input("Insert a number: "))  
    rectangle(a,b)
elif type == "rhombus":
    a = float(input("Insert a number: ")) 
    h = float(input("Insert a number: "))  
    rhombus(a,h)
elif type == "trapeze":
    a = float(input("Insert a number: ")) 
    b = float(input("Insert a number: "))  
    h = float(input("Insert a number: "))  
    trapeze(a,b,h)
else:
    print("Invalid input. Try again...")
