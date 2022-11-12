
public class Company {
    private String Name;
    private String DateOfCreation;
    private String ID;

    public Company(String Name, String DateOfCreation, String ID){
        this.Name = Name;
        this.DateOfCreation = DateOfCreation;
        setID(ID);
    }

    public String getName(){
        return Name;
    }

    public void setName(String Name){
        this.Name = Name;
    }

    public String getDateOfCreation(){
        return DateOfCreation;
    }

    public void setDateOfCreation(String DateOfCreation){
        this.DateOfCreation = DateOfCreation;
    }

    public String getID(){
        return ID;
    }

    public void setID(String ID){
        if(ID.length() != 10){
            System.out.println("Invalid length");
            return;
        }
        this.ID = ID;
    }

}
