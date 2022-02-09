import sys
import json

class GSMMobileDevices:
    def __init__(self, quality, price, year, creator, model):
        self.quality = quality
        self.price = price
        self.year = year
        self.creator = creator
        self.model = model

phones = list()

phones.append(GSMMobileDevices(50, 2000, 2015, 'Samsung', 'S5'))
phones.append(GSMMobileDevices(30, 1500, 2020, 'Apple', 'Iphone5'))
phones.append(GSMMobileDevices(60, 1200, 2018, 'Apple', 'Iphone 9'))
phones.append(GSMMobileDevices(34, 1900, 2003, 'Apple', 'Iphone 7'))

def sortByQuality(list):
    list.sort(key = lambda p:p.quality)
    return list

def parsePhonesWithSameCreatorToJSON(phones):
    result = list()
    creator = input('Insert a creator: ')
    for phone in phones:
        if phone.creator == creator:
            result.append(phone.model)
        
        f = open('randomFile.json', 'w')
        f.write(json.dumps(result))
        f.close()
            

phones = sortByQuality(phones)
parsePhonesWithSameCreatorToJSON(phones)

for phone in phones:
    print(phone.quality)
