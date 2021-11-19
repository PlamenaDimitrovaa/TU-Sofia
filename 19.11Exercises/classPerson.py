class Person:
    def __init__(self,fname,lname,ages,nat):
        self.firstname = fname
        self.lastname = lname
        self.age = ages
        self.nationality = nat
    def printing(self):
        print("Hello, my name is " + self.firstname + " "  + self.lastname + ", I'm " + self.age 
        + " years old" + " and I'm from " + self.nationality)

myPerson = Person("Plamena", "Dimitrova", "19" , "Bulgaria")
myPerson.printing()

class Student(Person):
    def printstudent(self):
        print("Hello, my name is " + self.firstname + " "  + self.lastname + ", I'm " + self.age 
        + " years old" + " and I'm from " + self.nationality)
    pass
MyStudent = Student("Ivan", "Georgiev", "50", "Italia")
MyStudent.printstudent()