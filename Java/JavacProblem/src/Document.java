import java.io.Serializable;

public class Document implements Serializable {

    private static final long serialVersionUID = 1L;
    private String name;
    private double success;
    private double income;
    private String faculty;

    public Document(String name, double success, double income, String faculty) {
        this.name = name;
        this.income = income;
        this.success = success;
        this.faculty = faculty;
    }

    public String getName(){
        return this.name;
    }

    public void setName(String name){
        this.name = name;
    }

    public double getSuccess(){
        return this.success;
    }

    public void setSuccess(double success){
        this.success = success;
    }

    public double getIncome(){
        return this.income;
    }

    public void setIncome(double income){
        this.income = income;
    }

    public String getFaculty(){
        return this.faculty;
    }

    public void setFaculty(String faculty){
        this.faculty = faculty;
    }
}
