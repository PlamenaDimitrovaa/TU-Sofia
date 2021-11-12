list = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15]
num = int(input("Insert a num: "))

def func(list, num):

    for i in range(len(list)):
        if list[i] > num:
            list[i] = 0
    return list

func(list, num)
print(list)