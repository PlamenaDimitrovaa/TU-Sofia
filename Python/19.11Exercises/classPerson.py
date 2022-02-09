class Person:
    def __init__(self,fname,lname,ages,nat):
        self.firstname = fname
        self.lastname = lname
        self.age = ages
        self.nationality = nat
    def printing(self):
        print(self.firstname, self.lastname, self.age, self.nationality)

myPerson = Person("Plamena", "Dimitrova", 19 , "Bulgarian")
myPerson.printing()

class Student(Person):
    def __init__(self,fname,lname,ages,nat,uni,year):
        super().__init__(fname,lname,ages,nat)
        self.university = uni
        self.yearofstudy = year
    def printing(self):
        print(self.firstname, self.lastname, self.age, self.nationality, self.university, self.yearofstudy)
myStudent = Student("Ivan", "Ivanov", 32, "Italian", "TU", 2005)
myStudent.printing()

class Lecteur(Person):
    def __init__(self,fname,lname,age,nat,uni,exp):
        super().__init__(fname,lname,age,nat)
        self.university = uni
        self.experience = exp
    def printing(self):
        print(self.firstname,self.lastname,self.age,self.nationality,self.university,self.experience)

myLecteur = Lecteur("Kostadin", "Georgiev", 50, "Bulgarian", "SU", 20)
myLecteur.printing()




