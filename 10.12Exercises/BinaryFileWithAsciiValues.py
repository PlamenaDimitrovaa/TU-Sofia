new_file = open("C:\\Users\\User\\Desktop\\TU-Sofia\\10.12Exercises\\document.bin", mode = "wb")
new_file.write(b"This is good")
new_file.close()

new_file = open("C:\\Users\\User\\Desktop\\TU-Sofia\\10.12Exercises\\document.bin", mode = "r")
ascii_values = []

for text in new_file:
    for c in text:
        ascii_values.append(ord(c))
print(ascii_values)
new_file.close()