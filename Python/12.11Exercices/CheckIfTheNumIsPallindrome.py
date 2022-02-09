def pallindrom(number):
    str1 = str(num)
    str2 = str1[::-1]
    if str1 == str2:
        return 1
    return 0

num = input("Insert a number: ")
print(pallindrom(num))