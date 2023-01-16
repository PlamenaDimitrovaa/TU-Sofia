import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.*;
import java.util.stream.Collectors;

public class Server {
    private static final String usersFilename = "users.bin";
    private ServerSocket server;

    public Server(){
        initAdmins();
    }

    public void start(){
        try{
            System.out.println("Server is listening");
            server = new ServerSocket(8080);
            while(true){
                Socket client = server.accept();
                Thread clientThread = new Thread(() -> {
                    System.out.println("Accepted client");
                    Scanner sc = null;
                    PrintStream out = null;
                    try{
                        sc = new Scanner(client.getInputStream());
                        out = new PrintStream(client.getOutputStream());
                        userMenu(sc, out);
                    }
                    catch(IOException e){
                        e.printStackTrace();
                    }
                    finally {
                        if(sc != null){
                            sc.close();
                        }
                        if (out != null) {
                            out.close();
                        }
                    }
                });

                clientThread.start();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
    public void initAdmins(){
        if(new File(usersFilename).exists()){
            return;
        }

        List<User> users = new ArrayList<>();
        users.add(new Admin("Admin", "12345"));
        saveUsers(users);
    }

    @SuppressWarnings("unchecked")
    public List<User> loadUsers(){
        try(ObjectInputStream in = new ObjectInputStream(new FileInputStream(usersFilename))){
            return (List<User>) in.readObject();
        }
        catch (IOException e){
            if(e instanceof InvalidClassException){
                throw new RuntimeException("Error", e);
            }
            e.printStackTrace();
        } catch (ClassNotFoundException e){
            throw new RuntimeException(e);
        }

        return null;
    }

    public void saveUsers(List<User> users){
        try(ObjectOutputStream out = new ObjectOutputStream(new FileOutputStream(usersFilename))){
            out.writeObject(users);
        }
        catch(IOException e){
            e.printStackTrace();
        }
    }

    private void registerUser(String username, String password, UserType userType) throws CredentialsException{
        User user = UserFactory.createUser(username, password, userType);
        synchronized (this){
            List<User> users = loadUsers();
            users.add(user);
            saveUsers(users);
        }
    }

    private User login(String username, String password){
        synchronized (this){
            for (User user: loadUsers()){
                if (Objects.equals(user.getUsername(), username) && Objects.equals(user.getPassword(), password)) {
                    return user;
                }
            }

            return null;
        }
    }

    private void userMenu(Scanner sc, PrintStream out){
        while(true){
            out.println("Login? Y/N");
            String login = sc.nextLine();
            if(!login.equalsIgnoreCase("Y")){
                out.println("Goodbye.");
                return;
            }

            out.println("Enter username: ");
            String username = sc.nextLine();
            out.println("Enter password: ");
            String password = sc.nextLine();

            User user = login(username, password);

            if(user == null){
                out.println("Error");
                continue;
            }

            switch(user.getUserType()){
                case ADMIN:{
                    adminMenu(sc, out, (Admin) user);
                    break;
                }
                case STUDENT:{
                    studentMenu(sc, out, (Student) user);
                    break;
                }
                case TEACHER:{
                    teacherMenu(sc, out, (Teacher) user);
                    break;
                }
            }
        }
    }

    private void adminMenu(Scanner sc, PrintStream out, Admin admin){
        out.println("Logged in as admin.");
        out.println("Enter user type to create: ADMIN | STUDENT | TEACHER");
        try{
            UserType userType = UserType.valueOf(sc.nextLine().toUpperCase());
            out.println("Enter username: ");
            String username = sc.nextLine();
            out.println("Enter password: ");
            String password = sc.nextLine();

            registerUser(username, password, userType);
            out.println("Success");
        } catch(IllegalArgumentException e){
            out.println("Invalid user type");
        } catch(CredentialsException e){
            out.println(e.getMessage());
        }
    }

    private void studentMenu(Scanner sc, PrintStream out, Student student){
        out.println("Logged in as student.");
        List<Grade> sortedGrades = student.getGrades()
                .stream()
                .sorted(Comparator.comparingInt(Grade::getSemesterNumber).thenComparing(Grade::getSubject))
                .collect(Collectors.toList());
        out.println(sortedGrades);
    }

    private void teacherMenu(Scanner sc, PrintStream out, Teacher teacher){
        out.println("Logged in as teacher.");
        out.println("Enter faculty number: ");
        String facultyNumber = sc.nextLine();
        out.println("Enter subject: ");
        String subject = sc.nextLine();
        out.println("Enter semester number: ");
        int semesterNumber = sc.nextInt();
        out.println("Enter grade: ");
        double gradeValue = sc.nextDouble();

        Grade grade = new Grade(subject, semesterNumber, gradeValue);

        synchronized (this){
            List<User> users = loadUsers();
            for (User user: users){
                if(user.getUsername().equals(facultyNumber) && user instanceof Student){
                    Student student = (Student) user;
                    student.getGrades().add(grade);
                    saveUsers(users);
                    out.println("Success");
                    return;
                }
            }

            out.println("No such student");
        }
    }
}