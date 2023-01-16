import java.io.IOException;
import java.io.PrintStream;
import java.net.Socket;
import java.util.Scanner;

public class Client {

    public static void main(String[] args){
        Socket server = null;
        Scanner console = null;
        Scanner sc = null;

        try{
            server = new Socket("localhost", 8080);
            console = new Scanner(System.in);
            sc = new Scanner(server.getInputStream());
            PrintStream out = new PrintStream(server.getOutputStream());
            userMenu(console, sc, out);
        }
        catch(IOException e){
            e.printStackTrace();
        }
        finally {
            if(server != null){
                try{
                    server.close();
                }
                catch(IOException e){
                    e.printStackTrace();
                }
            }

            if(console != null){
                console.close();
            }

            if(sc != null){
                sc.close();
            }
        }
    }

    private static void userMenu(Scanner console, Scanner sc, PrintStream out){
        while(true){
            System.out.println(sc.nextLine());
            out.println(console.nextLine());
            String next = sc.nextLine();
            System.out.println(next);
            if(next.equals("Goodbye")){
                return;
            }

            out.println(console.nextLine());
            System.out.println(sc.nextLine());

            out.println(console.nextLine());
            next = sc.nextLine();
            System.out.println(next);
            if(next.startsWith("Error")){
                continue;
            }
            if(next.equals("Logged in as admin")){
                adminMenu(console, sc, out);
            }
            if(next.equals("Logged in as student")){
                studentMenu(console, sc, out);
            }
            if(next.equals("Logged in as teacher")){
                teacherMenu(console, sc, out);
            }
        }
    }

    private static void adminMenu(Scanner console, Scanner sc, PrintStream out){
        System.out.println(sc.nextLine());
        out.println(console.nextLine());
        String next = sc.nextLine();
        System.out.println(next);

        if(next.startsWith("Error")){
            return;
        }

        out.println(console.nextLine());
        System.out.println(sc.nextLine());
    }

    private static void studentMenu(Scanner console, Scanner sc, PrintStream out){
        System.out.println(sc.nextLine());
    }
    private static void teacherMenu(Scanner console, Scanner sc, PrintStream out){
        System.out.println(sc.nextLine());
        out.println(console.nextLine());

        System.out.println(sc.nextLine());
        out.println(console.nextLine());

        System.out.println(sc.nextLine());
        out.println(console.nextLine());

        System.out.println(sc.nextLine());
        out.println(console.nextLine());

        System.out.println(sc.nextLine());
    }
}
