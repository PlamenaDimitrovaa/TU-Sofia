import java.io.Serializable;
import java.util.Objects;

public class Grade implements Serializable {
    private String subject;
    private int semesterNumber;
    private double grade;

    public Grade(String subject, int semesterNumber, double grade){
        this.subject = subject;
        this.semesterNumber = semesterNumber;
        this.grade = grade;
    }

    public String getSubject(){
        return this.subject;
    }

    public void setSubject(String subject){
        this.subject = subject;
    }

    public int getSemesterNumber(){
        return this.semesterNumber;
    }

    public void setSemesterNumber(int semesterNumber){
        this.semesterNumber = semesterNumber;
    }

    public double getGrade(){
        return this.grade;
    }

    public void setGrade(double grade){
        this.grade = grade;
    }

    @Override
    public String toString(){
        return "Subject: " + subject + "Semester Number: " + semesterNumber + "Grade: " + grade;
    }

    @Override
    public boolean equals(Object o){
        if(this == o){
            return true;
        }
        if(o == null || getClass() != o.getClass()){
            return false;
        }

        Grade grade1 = (Grade) o;
        return semesterNumber == grade1.semesterNumber && grade == grade1.grade && Objects.equals(subject, grade1.subject);
    }

    @Override
    public int hashCode(){
        return Objects.hash(subject,semesterNumber,grade);
    }
}
