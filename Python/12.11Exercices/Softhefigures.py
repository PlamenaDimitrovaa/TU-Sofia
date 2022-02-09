
def square(a):
    s = a*a
    print(s)

def rectangle(a,b):
    s = a*b
    print(s)

def triangle(a, b):
    s = (a*b)/2
    print(s)

type_figure = input('Type of the figure: ')
if type_figure == "square":
    a = float(input('Insert a: '))
    square(a)
elif type_figure == "rectangle":
    a = float(input('Insert a: '))
    b = float(input('Insert b: '))
    rectangle(a,b)
elif type_figure == "triangle":
    a = float(input('Insert a: '))
    b = float(input('Insert b: '))
    triangle(a,b)