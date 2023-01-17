import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.Scanner;

public class Student {

    public static void main(String[] args) {
        System.out.print("Въведете името си: ");
        Scanner sc = new Scanner(System.in);
        String name = sc.nextLine();
        System.out.print("Въведете среден успех: ");
        double success = sc.nextDouble();
        sc.nextLine();
        System.out.print("Въведете доход: ");
        double income = sc.nextDouble();
        sc.nextLine();
        System.out.print("Въведете факултет: ");
        String faculty = sc.nextLine();
        System.out.print("Въведете тип на документа: ");
        String docType = sc.nextLine();
        Document doc = new Document(name, success, income, faculty);
        Socket sock;
        try {
            sock = new Socket("localhost", 5000);
        } catch (IOException ex) {
            System.out.println("Can't connect to server");
            return;
        }
        try(ObjectInputStream in = new ObjectInputStream(sock.getInputStream())){
            System.out.println(in.readUTF());
            try(ObjectOutputStream out = new ObjectOutputStream(sock.getOutputStream())){
                System.out.print("Програмата изпраща типа на документа към сървъра...");
                out.writeUTF(docType);
                out.flush();
                System.out.println(" готово!");
                String response = in.readUTF();
                System.out.println(response);
                if(!response.equals("OK")){
                    System.out.println("Изпратихме несъществуващ тип документ");
                    return;
                }
                System.out.print("Програмата изпраща документа към сървъра...");
                out.writeObject(doc);
                out.flush();
                System.out.println(" готово!");
            }
        } catch (IOException ex) {
            System.out.println(ex.getMessage());
        }
    }
}
