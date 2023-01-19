import java.util.ArrayList;
import java.util.List;
import java.util.regex.Pattern;

public class RegexTester {

    public static List<Boolean> test(Regex regex, String[] strings) {

        List<Boolean> result = new ArrayList<Boolean>();

        Pattern pattern = Pattern.compile(regex.getPattern());

        for (int i = 0; i < strings.length; i++) {

            if (pattern.matcher(strings[i]).matches()) {
                result.add(true);
            } else {
                result.add(false);
            }
        }
        return result;
    }
}
