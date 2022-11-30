import java.util.*;

public class Main {
    public static void main(String[] args){
        Scanner scanner = new Scanner(System.in);
        String text = scanner.nextLine();
        LinkedList<String> linkedList = new LinkedList<String>();
        linkedList.add(text);
        for (int i = 0; i < 5; i++){
            text = scanner.nextLine();
            linkedList.add(text);
        }
        System.out.println(linkedList);

        Collections.sort(linkedList);

        System.out.println(linkedList);

        ArrayList<String> arrayList = new ArrayList<String>();

        for (int i = 0; i < linkedList.size(); i ++){
            arrayList.add(linkedList.get(i));
        }

        System.out.println(arrayList);

        HashMap hashMap = new HashMap<String, Integer>();
        for(char ch = 'A'; ch <= 'Z'; ++ch){
            hashMap.put(String.valueOf(ch), (int)ch);
        }

        System.out.println(hashMap);

        HashMap letters = new HashMap<Character, Integer>();

        int counter = 0;

        for (char ch = 'A'; ch <= 'Z'; ch++){
            counter++;
            letters.put(ch, counter);
        }

        Scanner sc = new Scanner(System.in);
        String letter = sc.nextLine();

        while(!sc.equals("end")){
            System.out.println(letters.get(letter.charAt(0)));
            letter = sc.nextLine();
        }
    }
}