import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String line = scanner.nextLine();
        File file = new File("file.txt");
        try{
            boolean isCreated = file.createNewFile();
            if (isCreated){
                System.out.println("File has been created successfully.");
            } else {
                System.out.println("File already present at the specified location.");
            }
        } catch(IOException e){
            System.out.println("Exception occurred:");
            e.printStackTrace();
        }

        try{
            FileWriter fileWriter = new FileWriter("file.txt");
            fileWriter.write(line);
            fileWriter.close();
        } catch(IOException e) {
            System.out.println("Exception occurred:");
            e.printStackTrace();
        }

        try{
            File newFile = new File("newFile.txt");
            Scanner reader = new Scanner(file);
            FileWriter newFileWriter = new FileWriter("newFile.txt");

            while(reader.hasNextLine()){
                String data = reader.nextLine();
                StringBuilder sb = new StringBuilder(data).reverse();
                newFileWriter.write(sb.toString());
                System.out.println(sb.toString());
            }

            newFileWriter.close();
            reader.close();
        } catch(IOException e){
            System.out.println("Error occurred:");
            e.printStackTrace();
        }
    }
}