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
 
School::School(int levels, int number) : Building(levels)
{
    this->number = number;
}
 
void School::printData()
{
    // cout << this->number << endl;
    cout << number << endl;
    printLevels();
    // cout << this->levels << endl;
}
 
int main()
{
    School schoolObject(5, 100);
    schoolObject.printData();
 
    cout << "Hello world!" << endl;
    return 0;
}