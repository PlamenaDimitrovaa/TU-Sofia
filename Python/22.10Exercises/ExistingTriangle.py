a = int(input("enter side a: "))
b = int(input("enter side b: "))
c = int(input("enter side c: "))

if (a+b>c and a+c>b and b+c>a):
    print("This triangle exists!")
else: 
    print("This triangle doesn't exist!")
