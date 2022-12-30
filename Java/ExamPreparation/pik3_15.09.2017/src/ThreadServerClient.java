import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.ArrayList;

public class ThreadServerClient extends Thread {

    Socket socket;
    DataInputStream in;
    DataOutputStream out;
    String destination;
    private int offertId;
    public ThreadServerClient(Socket socket){
        this.socket = socket;
    }

    public void reservation(){
        System.out.println("Enter your destination");
    }

    public boolean evaluation(){
        return true;
    }

    public void rating(){
        try{
            ArrayList<int> grades = new ArrayList<int>();

            for(int i = 0; i <= grades.size(); i++ ){
                for (int j = 0; j <= 6; j++){
                    System.out.println("Send offerId");
                }

                if (!(offertId == grades.get(i)) & evaluation() == false){
                    System.out.println("Enter your grade");
                }

                int average = 0;
                for (int k = 0; k<offertId; k++){
                    average += offertId;
                }
            }
        } catch(IOException e){

        }
    }

    static ArrayList<Offerts> offerts;
    static ArrayList<User> users;

    @Override
    public void run(){
        try{
            this.in = new DataInputStream(socket.getInputStream());
            this.out = new DataOutputStream(socket.getOutputStream());
            System.out.println("Two opportunities: reservation or rating");
        } catch (IOException e){
            System.out.println("Problem with input and output");
        }
    }
}
