
class RouterShop:
    def __init__(self, creator, code, price, quantity):
        self.creator = creator
        self.code = code
        self.price = price
        self.quantity = quantity

class ShoppingCart:
    def __init__(self, products = []):
        self.products = products
    def Add(self, product):
        self.products.append(product)
    def GetTotalPrice(self, product):
        totalPrice = 0
        deliveryPrice = 10
        for i in range(0, len(self.products)):
            totalPrice += self.products[i].price + self.products[i].price * 0.2 + deliveryPrice

        f = open("file.txt", "a")
        f.write(totalPrice)
        f.close()




    