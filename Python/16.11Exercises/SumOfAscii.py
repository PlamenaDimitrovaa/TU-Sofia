# def getSum(n):
#     sum = 0
#     for digit in str(n):
#         sum += int(digit)
#     return(sum)
# def second():
#     str = input("String: ")
#     thisdict = {}
#     myTuple = tuple(str)
#     for i in range (len(myTuple)):
#         asci = ord(myTuple[i])
#         thisdict[asci] = getSum(asci)
#     print(thisdict)
# second()

str = input('Enter a string: ')
dictionary = {}
for i in str:
    a = ord(i)
    b =a  
    sum = 0

    while a!= 0:
        k = a% 10
        a = a//10
        sum = sum + k
    dictionary[b] = sum

print(dictionary)