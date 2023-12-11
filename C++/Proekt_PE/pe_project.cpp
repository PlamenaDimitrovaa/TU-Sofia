#include <iostream>
#include <vector>
#include <algorithm>
#include <fstream>

using namespace std;

class Project {

    private: 
        int Id;
        string Name;

    public:
        Project() : Id(0), Name("Default") {}
        Project(int id, const string& name) 
            : Id(id), Name(name) {}
        ~Project(){
            this->Id = 0;
            this->Name = "";
        }

    int getProjectId() const { return Id; }
    void setProjectId(int id) { 

        if (id < 0)
        {
            cout  << "Invalid data";
            return;
        }

        Id = id; 
    }

    string getProjectName() const { return Name; }
    void setProjectName(const string& name) { 
        
        if(name.empty())
        {
            cout  << "Invalid project name";
            return;
        }

        Name = name; 
    }

    friend ostream& operator<<(ostream& out, const Project& proj);
};

ostream& operator<<(ostream& out, const Project& proj) {
    out << "Project ID: " << proj.Id << "\nName: " << proj.Name << "\n";
    return out;
}


class Employee {

    private:
        int Id;
        string Name;
        string PersonalId;
        double WorkExperience;
        int HourlyContract;
        vector<Project> Projects = {};
    
    public:
        Employee() : Id(0), Name("Default"), PersonalId("0000000000"), WorkExperience(2), HourlyContract(8) {}
        Employee(int id, string name, string personalId, double workExperience, int hourlyContract) 
            : Id(id), Name(name), PersonalId(personalId), WorkExperience(workExperience), HourlyContract(hourlyContract) {}
        ~Employee(){
            this->Id = 0;
            this->Name = "";
            this->PersonalId = "";
            this->WorkExperience = 0;
            this->HourlyContract = 0;
        }

        

    int getEmployeeId() const { return Id; }
    void setEmployeeId(int id) { 

        if (id < 0)
        {
            cout  << "Invalid data";
            return;
        }
        
        Id = id; 
    }

    string getEmployeeName() const { return Name; }
    void setEmployeeName(const string& name) {

        if(name.empty())
        {
            cout  << "Invalid name";
            return;
        }

        Name = name; 
    }

    int getEmployeePersonalId() const { return Id; }
    void setEmployeePersonalId(string id) {
        
        if (id.empty())
        {
            cout  << "Invalid personal id";
            return;
        }
        
        PersonalId = id; 
    }

    double getWorkExperience() const { return WorkExperience; }
    void setWorkExperience(double experience) { 

        if (experience <= 0)
        {
            cout  << "Invalid work experience";
            return;
        }
        
        WorkExperience = experience; 
    }

    int getHourlyContract() const { return HourlyContract; }
    void setHourlyContract(int hours) {

        if (hours <= 0)
        {
            cout << "Invalid hours";
            return;       
        }
        
         HourlyContract = hours; 
    }

    vector<Project> getProjects() const { return Projects; }
    void addProjects(const Project& project){ Projects.push_back(project); }

    friend ostream& operator<<(ostream& out, const Employee& emp);
};

ostream& operator<<(ostream& out, const Employee& emp) {
    out << "Employee ID: " << emp.Id << "\nName: " << emp.Name << "\n";
    return out;
}

class Department {

    private:
        int Id;
        string Name;
        vector<Employee> Employees = {};
        int EmployeesCount;
        string DateOfCreation;

    public:
        Department() : Id(0), Name("Default"), DateOfCreation("12/12/2020") {}
        Department(int id, string name, string dateOfCreaion) 
            : Id(id), Name(name), DateOfCreation(dateOfCreaion) {}
        ~Department(){
            this->Id = 0;
            this->Name = "";
            this->Employees = {};
            this->EmployeesCount = 0;
            this->DateOfCreation = "";
        }

    int getDepartmentId() const { return Id; }
    void setDepartmentId(int id) { 
        
         if (id < 0)
        {
            cout << "Invalid data";
            return;
        }

        Id = id;        
    }

    string getDepartmentName() const { return Name; }
    void setDepartmentName(string& name) { 
        
        if(name.empty())
        {
            cout  << "Invalid department name";
            return;
        }
        
        Name = name;    
    }

    vector<Employee> getEmployees() const { return Employees; }
    void addEmployees(const Employee& Employee) { Employees.push_back(Employee); }

    int getEmployeesCount() const { 
        
        if (Employees.size() == 0)
        {
            cout << "No employees";
        } 
        else {
            return Employees.size(); 
        }
    }

    string getDateOfCreation() const { return DateOfCreation; }
    void setDateOfCreation(string date) { DateOfCreation = date; } //Check the date!

    friend ostream& operator<<(ostream& out, const Department& dep);
};

ostream& operator<<(ostream& out, const Department& dep) {
    out << "Department ID: " << dep.Id << "\nName: " << dep.Name << "\n" << "\nDate of creation: " << dep.DateOfCreation << "\n";
    return out;
}

class Company {

    private:
        int Id;
        string Name;
        string CompanyType;
        bool VATRegistered;
        vector<Department> Departments = {}; 

    public:
        Company() : Id(0), Name("Default"), CompanyType("OOD"), VATRegistered(true) {}
        Company(int id, string name, string companyType, bool vat) 
            : Id(id), Name(name), CompanyType(companyType), VATRegistered(vat) {}
        ~Company(){
            this->Id = 0;
            this->Name = "";
            this->CompanyType = "";
            this->VATRegistered = false;
            this->Departments = {};
        }

    int getCompanyId() const { return Id; }
    void setCompanyId(int id) { 

        if (id < 0)
        {
            cout << "Invalid data";
            return;
        }
        
        Id = id;      
    }

    string getCompanyName() const { return Name; }
    void setCompanyName(string& name) { 
        
        if(name.empty())
        {
            cout  << "Invalid company name";
            return;
        }

        Name = name; 
    }

    string getCompanyType() const { return CompanyType; }
    void setCompanyType(string& type) {
        
        if (type != "OOD" && type != "EOOD" && type != "AD")
        {
            cout << "Invalid company type";
            return;
        }
        
        CompanyType = type;
    }

    bool getVATRegistered() const { return VATRegistered; }
    void setVATRegistered(bool vat) { VATRegistered = vat; }

    vector<Department> getDepartments() const { return Departments; }
    void addDepartment(const Department& department) { Departments.push_back(department); }

     friend ostream& operator<<(ostream& out, const Company& com);
};

ostream& operator<<(ostream& out, const Company& com) {
    out << "Company ID: " << com.Id << "\nName: " << com.Name << "\n" << "\nCompany Type: " << com.CompanyType << "\n" << "\nVAT Registered: " << com.VATRegistered << "\n";
    return out;
}


int displayMenu() {
    int choice;
    cout << "\nMenu:\n";
    cout << "1. Add Company\n";
    cout << "2. Add Department\n";
    cout << "3. Add Employee\n";
    cout << "4. Add Project\n";
    cout << "5. Save Data to File\n";
    cout << "6. Read Data from File\n";
    cout << "0. Exit\n";
    cout << "Enter your choice: ";
    cin >> choice;
    return choice;
}

template <typename T>
void saveDataToFile(const vector<T>& data, const string& fileName) {
    ofstream outFile(fileName);
    if (!outFile) {
        cerr << "Error: Unable to open file for writing.\n";
        return;
    }

    for (const auto& item : data) {
        outFile << item << '\n';
    }

    cout << "Data saved to file successfully.\n";
}

void readDataFromFile(string fileName){
    ifstream inputFile(fileName);
 
    if (inputFile.is_open())
    {
        string line;
 
        while (getline(inputFile, line))
        {
            cout << line << endl;
        }
 
        inputFile.close();
    }
    else
    {
        cerr << "Unable to open file for reading." << endl;
    }
}

int main() {

    vector<Company> companies;
    vector<Department> departments;
    vector<Employee> employees;
    vector<Project> projects;

    int choice;

    do {
        choice = displayMenu();

        switch (choice) {
            case 1: {
                Company company;
                int id;
                string name;
                string type;
                bool vat;

                cout << "Enter Company Id: ";
                cin >> id;
                company.setCompanyId(id);

                cout << "Enter Company Name: ";
                cin >> name;
                company.setCompanyName(name);

                cout << "Enter Company Type (OOD, EOOD, AD): ";
                cin >> type;
                company.setCompanyType(type);

                cout << "Is the Company VAT Registered? (1 for Yes, 0 for No): ";
                cin >> vat;
                company.setVATRegistered(vat);

                companies.push_back(company);

                cout << "Company information set successfully.\n";
                break;
            }
            case 2: {
                Department department;
    
                int id;
                string name;
                string dateOfCreation;

                cout << "Enter Department ID: ";
                cin >> id;
                department.setDepartmentId(id);

                cout << "Enter Department Name: ";
                cin >> name;
                department.setDepartmentName(name);

                cout << "Enter Date of Creation (format: DD/MM/YYYY): ";
                cin >> dateOfCreation;
                department.setDateOfCreation(dateOfCreation);

                departments.push_back(department);
                cout << "Department information set successfully.\n";
                break;
            }
            case 3: {
               Employee employee;

                int id;
                string name;
                string personalId;
                double workExperience;
                int hourlyContract;

                cout << "Enter Employee ID: ";
                cin >> id;
                employee.setEmployeeId(id);

                cout << "Enter Employee Name: ";
                cin >> name;
                employee.setEmployeeName(name);

                cout << "Enter Personal ID: ";
                cin >> personalId;
                employee.setEmployeePersonalId(personalId);

                cout << "Enter Work Experience: ";
                cin >> workExperience;
                employee.setWorkExperience(workExperience);

                cout << "Enter Hourly Contract: ";
                cin >> hourlyContract;
                employee.setHourlyContract(hourlyContract);

                employees.push_back(employee);
                cout << "Employee information set successfully.\n";
                break;
            }
            case 4: {
                Project project;

                int id;
                string name;

                cout << "Enter Project ID: ";
                cin >> id;
                project.setProjectId(id);

                cout << "Enter Project Name: ";
                cin >> name;
                project.setProjectName(name);

                projects.push_back(project);
                cout << "Project information set successfully.\n";
                break;
            }
            case 5:
                saveDataToFile(companies, "companies.txt");
                saveDataToFile(departments, "departments.txt");
                saveDataToFile(employees, "employees.txt");
                saveDataToFile(projects, "projects.txt");
                break;
            case 6:
                readDataFromFile("companies.txt");
                readDataFromFile("departments.txt");
                readDataFromFile("employees.txt");
                readDataFromFile("projects.txt");
                break;
            case 0:
                std::cout << "Exiting program.\n";
                break;
            default:
                std::cout << "Invalid choice. Please try again.\n";
                break;
        }

    } while (choice != 0);

    return 0;
}