import java.util.regex.Pattern;
public class UserFactory {

    private static final Pattern facultyNumberPattern = Pattern.compile("\\d{9}");
    private static final Pattern EGNPattern = Pattern.compile("\\d{10}");
    private static final Pattern emailPattern = Pattern.compile("[a-z]+@tu-sofia.bg");

    public static User createUser(String username, String password, UserType userType) throws CredentialsException{
        switch(userType){
            case ADMIN:{
                return new Admin(username, password);
            }
            case STUDENT:{
                if(!facultyNumberPattern.matcher(username).matches()){
                    throw new CredentialsException("Invalid faculty number");
                }
                if (!EGNPattern.matcher(password).matches()) {
                    throw new CredentialsException("Invalid EGN");
                }

                return new Student(username, password);
            }
            case TEACHER:{
                if(!emailPattern.matcher(username).matches()){
                    throw new CredentialsException("Invalid email");
                }
                if(password.length() < 5){
                    throw new CredentialsException("Invalid password");
                }

                return new Teacher(username, password);
            }
            default:
                return null;
        }
    }
}
