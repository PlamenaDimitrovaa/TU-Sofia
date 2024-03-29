public class Teacher extends User {
    public Teacher(String email, String password){
        super(email, password);
    }

    @Override
    public UserType getUserType(){
        return UserType.TEACHER;
    }

    @Override
    public String toString(){
        return "Teacher{} " + super.toString();
    }
}
