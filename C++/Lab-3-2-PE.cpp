#include <iostream>
 
using namespace std;
 
class Building
{
    // protected:
    // public:
private:
    int levels;
 
protected:
    void printLevels();
 
public:
    Building(int);
};
 
Building::Building(int levels) : levels{levels}
{
    // this->levels = levels; alternative way of initializing members of the class
}
 
void Building::printLevels()
{
    cout << levels << endl;
}
 
class School : public Building
{
private:
    int number;
 
public:
    School(int, int);
    void printData();
};
 
// class HighSchool : public School
class HighSchool : protected School
{
private:
    string speciality;
 
public:
    HighSchool(string, int, int);
    void printDataForHighSchool();
};
 
School::School(int levels, int number) : Building(levels)
{
    this->number = number;
}
 
HighSchool::HighSchool(string speciality, int levels, int number) : School(levels, number)
{
    this->speciality = speciality;
}
 
void School::printData()
{
    // cout << this->number << endl;
    cout << number << endl;
    printLevels();
    // cout << this->levels << endl;
}
 
void HighSchool::printDataForHighSchool()
{
    // cout << this->speciality << endl;
    School::printData();
    cout << speciality << endl;
}
 
int main()
{
    School schoolObject(5, 100);
    // schoolObject.printData();
 
    HighSchool smg("Sofia Mathematical High School", 6, 1);
 
    // smg.printDataForHighSchool();
    smg.printDataForHighSchool();
 
    cout << "Hello world!" << endl;
    return 0;
}