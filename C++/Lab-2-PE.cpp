#include <iostream>
 
using namespace std;
 
class Teacher;
class Account;
class Bank
{
private:
    string name;
    Account *account1;
    Account *account2;
 
public:
    Bank(string, Account, Account);
    void giveBonusToAccounts(float);
};
class Student
{
private:
    string name;
    int age;
 
public:
    Student();
    Student(string, int);
    ~Student();
    string getName() const;
    friend bool areAgesEqual(Student student, Teacher teacher);
    void setName(string);
};
 
Student::~Student()
{
    cout << "Student class destructor" << endl;
}
 
void Student::setName(string name)
{
    this->name = name;
}
 
string Student::getName() const
{
    return name;
}
 
class Teacher
{
private:
    string name;
    int age;
 
public:
    Teacher();
    Teacher(string, int);
    void gradeStudent(const Student &, int grade);
    friend bool areAgesEqual(Student student, Teacher teacher);
};
 
Teacher::Teacher(string name, int age) : name{name}, age{age} {}
void Teacher::gradeStudent(const Student &student, int grade)
{
    string name = student.getName();
    cout << "Student " << name << " is graded with " << grade << endl;
    // student.setName("Oppppppppppppppps");
}
 
bool areAgesEqual(Student student, Teacher teacher)
{
    return student.age == teacher.age;
}
 
Student::Student()
{
    this->name = "";
    this->age = 0;
}
 
Student::Student(string name, int age) : name{name}, age{age}
{
}
 
class Account
{
private:
    int id;
    float ballance;
 
public:
    Account(int, float);
    Account();
    void printBallance();
    friend void Bank::giveBonusToAccounts(float);
};
 
Account::Account(int id, float ballance) : id{id}, ballance{ballance} {}
Account::Account() : id{0}, ballance{0.0} {}
 
void Account::printBallance()
{
    cout << "Ballance " << this->ballance << endl;
}
 
void Bank::giveBonusToAccounts(float bonus)
{
    account1->ballance += bonus;
    account2->ballance += bonus;
}
 
Bank::Bank(string name, Account a1, Account a2)
{
    (*this).name = name;
    account1 = &a1;
    this->account2 = &a1;
}
 
void changeVariable(int &number)
{
    number = 42;
    cout << "number in 'changeVariable' - " << number << endl; // 42
}
 
int main()
{
    cout << "Hello world!" << endl;
 
    int someNumberInMain = 1;
 
    changeVariable(someNumberInMain);
    // cout << "someNumberInMain in 'main function' - " << someNumberInMain << endl; // 1
 
    Teacher teacher("John", 30);
    Student student("Alex", 21);
 
    cout << student.getName() << endl;
    teacher.gradeStudent(student, 6);
    cout << student.getName() << endl;
 
    return 0;
}
 