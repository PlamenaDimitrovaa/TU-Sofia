import random 
random_list1 = []
random_list2 = []
for i in range(0,10):
    n1 = random.randint(1,30)
    n2 = random.randint(1,30)
    random_list1.append(n1)
    random_list2.append(n2)
print("The first list: ", random_list1)
print("The second list: ", random_list2)

new_list = []

for i in range(0, len(random_list1)):
    new_list.append(random_list1[i])
    new_list.append(random_list2[i])

  
print(new_list)           

    
