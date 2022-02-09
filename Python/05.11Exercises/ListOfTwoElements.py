
a = [1, 2, 6, 4, 9, 7, 8, 0]
def func(a):
        maxx = a[0]
        indexx = 0
        for i in range(1, len(a)):
            if a[i] > maxx:
                maxx = a[i]
                indexx = i
        b = [maxx, indexx]
        print(b)
func(a)
