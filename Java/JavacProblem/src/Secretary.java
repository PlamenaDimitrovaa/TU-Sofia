import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;

public class Secretary {

    public static void main(String[] args) throws IOException, ClassNotFoundException{
        Socket sock = new Socket("localhost", 5001);
        ObjectInputStream in = new ObjectInputStream(sock.getInputStream());
        System.out.println(in.readUTF());
        ObjectOutputStream out = new ObjectOutputStream(sock.getOutputStream());
        out.writeUTF("secret");
        out.flush();
        String passOK = in.readUTF();
        if(!passOK.equals("OK")){
            System.out.println("BAD PASSWORD!");
            return;
        }
        String docType = in.readUTF();
        if(docType.equals("NO DOCS")){
            System.out.println("Няма документи");
            return;
        }
        Document doc = (Document)in.readObject();
        if(docType.equals("special")){
            if(doc.getSuccess() < 5.30){
                System.out.println("По-нисък успех за специална молба на "+doc.getName()+". Отхвърлен!");
            }
            else if(doc.getSuccess() > 300.0){
                System.out.println("По-висок доход за специална молба на "+doc.getName()+". Отхвърлен!");
            }
            else{
                Socket sock2 = new Socket("localhost", 5002);
                ObjectOutputStream out2 = new ObjectOutputStream(sock2.getOutputStream());
                out2.flush();
                ObjectInputStream in2 = new ObjectInputStream(sock2.getInputStream());
                System.out.println(in2.readUTF());
                out2.writeUTF("secret");
                String response = in2.readUTF();
                if(!response.equals("OK")){
                    System.out.println("BAD PASSWORD WHEN CHECKING FOR APPROVED");
                    return;
                }
                out2.writeObject(doc);
                int approved = in2.readInt();
                if(approved > 5){
                    System.out.println("Отхвърлена специална молба на "+ doc.getName()+" заради повече от 5 одобрени");
                }
                else System.out.println("Одобрена специална молба на "+ doc.getName());
            }
        }
        else if(docType.equals("normal")){
            if(doc.getSuccess() < 5.50){
                System.out.println("По-нисък успех за нормална молба на "+ doc.getName()+". Отхвърлен!");
            }
            else if(doc.getIncome() > 500.0){
                System.out.println("По-висок доход за нормална молба на "+ doc.getName() +". Отхвърлен!");
            }
            else{
                Socket sock2 = new Socket("localhost", 5002);
                ObjectOutputStream out2 = new ObjectOutputStream(sock2.getOutputStream());
                out2.flush();
                ObjectInputStream in2 = new ObjectInputStream(sock2.getInputStream());
                System.out.println(in2.readUTF());
                out2.writeUTF("secret");
                String response = in2.readUTF();
                if(!response.equals("OK")){
                    System.out.println("BAD PASSWORD WHEN CHECKING FOR APPROVED");
                    return;
                }
                out2.writeObject(doc);
                int approved = in2.readInt();
                if(approved > 4){
                    System.out.println("Отхвърлена нормална молба на "+ doc.getName()+" заради повече от 4 одобрени");
                }
                else System.out.println("Одобрена нормална молба на "+ doc.getName());
            }
        }
    }
}
