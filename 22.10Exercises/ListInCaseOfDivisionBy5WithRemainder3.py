l = int(input('Golemina na spisyka: '))
numbers = []
for i in range(l):
    numbers.append(i * 5 + 3)
for i in numbers:
    print(i)

print()

for i in range(len(numbers)):
    print(numbers[len(numbers) - (i + 1)])
