def ReadTextFromFile(nameOfFile):
    text = open(nameOfFile)
    textToPrint = text.read()
    text.close()
    print(textToPrint)

try:
    ReadTextFromFile("file.txt")
except Exception:
    print("An exeption occured!")